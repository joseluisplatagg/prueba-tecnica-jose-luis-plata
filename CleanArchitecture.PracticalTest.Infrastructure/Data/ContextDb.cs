using Microsoft.EntityFrameworkCore;
using CleanArchitecture.PracticalTest.Domain.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using CleanArchitecture.PracticalTest.Domain.Constants;
using CleanArchitecture.PracticalTest.Domain.Entities;

namespace CleanArchitecture.PracticalTest.Infrastructure.Data;

public class ContextDb(DbContextOptions<ContextDb> options) : DbContext(options)
{
    static ContextDb()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    public DbSet<Paquete> Paquetes  => Set<Paquete>();
    public DbSet<Estado> Estados => Set<Estado>();
    public DbSet<Ruta> Rutas => Set<Ruta>();
    public DbSet<PaqueteHistorial> PaqueteHistorial => Set<PaqueteHistorial>();
    // Sobreescribir el metodo SaveChangesAsync para que se actualicen las propiedades de auditoria
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt= new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    entry.Entity.UpdatedBy = !entry.Entity.UpdatedBy.HasValue ?
                        Guid.Empty : entry.Entity.UpdatedBy;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextDb).Assembly);

        modelBuilder.Entity<Ruta>().HasData(
       new Ruta
       {
           RutaId = CatalogGuids.RutaCentro,
           Origen = "Ciudad de México",
           Destino = "Guadalajara",
           Distancia = 550.5m,
           TiempoEstimado = 6.5m,
           CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
           CreatedBy = new Guid()
       },
       new Ruta
       {
           RutaId = CatalogGuids.RutaNorte,
           Origen = "Monterrey",
           Destino = "Nuevo Laredo",
           Distancia = 220.0m,
           TiempoEstimado = 2.8m,
           CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
           CreatedBy = new Guid()
       },
       new Ruta
       {
           RutaId = CatalogGuids.RutaSur,
           Origen = "Cancún",
           Destino = "Mérida",
           Distancia = 300.2m,
           TiempoEstimado = 4.0m,
           CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
           CreatedBy = new Guid()
       }
   );

        modelBuilder.Entity<Estado>(st =>
        {
            st.HasKey(e => e.EstadoId);
            st.Property(e => e.EstadoDescripcion).IsRequired().HasMaxLength(100);

            st.HasData(
                new Estado { EstadoId = CatalogGuids.Registrado, EstadoDescripcion = "Registrado" },
                new Estado { EstadoId = CatalogGuids.EnBodega, EstadoDescripcion = "En Bodega" },
                new Estado { EstadoId = CatalogGuids.EnTransito, EstadoDescripcion = "En Transito" },
                new Estado { EstadoId = CatalogGuids.EnReparto, EstadoDescripcion = "En Reparto" },
                new Estado { EstadoId = CatalogGuids.Entregado, EstadoDescripcion = "Entregado" },
                new Estado { EstadoId = CatalogGuids.Devuelto, EstadoDescripcion = "Devuelto" });
        });

        modelBuilder.Entity<Paquete>(entity =>
        {
            entity.Property(e => e.Costo).HasColumnType("numeric(18,2)");
            entity.Property(e => e.Alto).HasColumnType("numeric(18,2)");
            entity.Property(e => e.Ancho).HasColumnType("numeric(18,2)");
            entity.Property(e => e.Largo).HasColumnType("numeric(18,2)");
            entity.Property(e => e.Costo).HasColumnType("numeric(18,2)");

            entity.HasOne(p => p.EstadoPaquete)
            .WithMany()
            .HasForeignKey(p => p.EstadoId)
            .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<PaqueteHistorial>(entity =>
        {
            entity.HasOne(h => h.Paquete)
            .WithMany(p => p.Historial)
            .HasForeignKey(f => f.PaqueteId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity <PaqueteHistorial>(entity =>
        {
            entity.HasOne(h => h.PaqueteEstado)
                .WithMany()
                .HasForeignKey(f => f.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    // Forzamos a que en la DB sea 'timestamp without time zone'
                    property.SetColumnType("timestamp");
                }
            }
        }

    }
}

public class PaqueteEstatusInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, InterceptionResult<int> result, CancellationToken ct = default)
    {
        var context = eventData.Context;
        if(context == null) return base.SavingChangesAsync(eventData, result, ct);

        var entries = context.ChangeTracker.Entries<Paquete>()
                .Where(p => p.State == EntityState.Added ||
                            (p.State == EntityState.Modified && p.Property(p => p.EstadoPaquete.EstadoId).IsModified));

        foreach( var entry in entries)
        {
            context.Set<PaqueteHistorial>().Add(new PaqueteHistorial
            {
                PaqueteId = entry.Entity.PaqueteId,
                PaqueteEstado = entry.Entity.EstadoPaquete,
                UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedBy = new Guid()
            });
        }

        return base.SavingChangesAsync(eventData, result, ct);
    }
}