using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.PracticalTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    estado_id = table.Column<Guid>(type: "uuid", nullable: false),
                    estado_descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_estados", x => x.estado_id);
                });

            migrationBuilder.CreateTable(
                name: "rutas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ruta_id = table.Column<Guid>(type: "uuid", nullable: false),
                    origen = table.Column<string>(type: "text", nullable: false),
                    destino = table.Column<string>(type: "text", nullable: false),
                    distancia = table.Column<decimal>(type: "numeric", nullable: false),
                    tiempo_estimado = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rutas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paquetes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    paquete_id = table.Column<Guid>(type: "uuid", nullable: false),
                    numero_rastreo = table.Column<string>(type: "text", nullable: false),
                    peso = table.Column<decimal>(type: "numeric", nullable: false),
                    alto = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ancho = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    largo = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    volumen = table.Column<decimal>(type: "numeric", nullable: false),
                    distancia = table.Column<decimal>(type: "numeric", nullable: false),
                    estado_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ruta_id = table.Column<Guid>(type: "uuid", nullable: false),
                    costo = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_paquetes", x => x.id);
                    table.ForeignKey(
                        name: "fk_paquetes_estados_estado_id",
                        column: x => x.estado_id,
                        principalTable: "estados",
                        principalColumn: "estado_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_paquetes_rutas_ruta_id",
                        column: x => x.ruta_id,
                        principalTable: "rutas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paquete_historial",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    paquete_id = table.Column<Guid>(type: "uuid", nullable: false),
                    estado_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha_hora_cambio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    motivo = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_paquete_historial", x => x.id);
                    table.ForeignKey(
                        name: "fk_paquete_historial_estados_estado_id",
                        column: x => x.estado_id,
                        principalTable: "estados",
                        principalColumn: "estado_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_paquete_historial_paquetes_paquete_id",
                        column: x => x.paquete_id,
                        principalTable: "paquetes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "estados",
                columns: new[] { "estado_id", "created_at", "created_by", "estado_descripcion", "id", "is_active", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("d12a3456-7890-abcd-ef01-234567890abc"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7202), new Guid("00000000-0000-0000-0000-000000000000"), "Registrado", new Guid("cd743b4f-d67d-4fed-af03-ab1dde078ef5"), true, new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7204), null },
                    { new Guid("d12a3456-7890-abcd-ef01-234567890abe"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7211), new Guid("00000000-0000-0000-0000-000000000000"), "En Reparto", new Guid("a5794df4-6fc3-4f7c-a091-87de51a12d37"), true, new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7211), null },
                    { new Guid("e23b4567-8901-bcde-f012-345678901bcd"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7207), new Guid("00000000-0000-0000-0000-000000000000"), "En Bodega", new Guid("a0e2c25f-91bb-4d76-9be2-ca2bad132599"), true, new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7207), null },
                    { new Guid("e23b4567-8901-bcde-f012-345678901bce"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7212), new Guid("00000000-0000-0000-0000-000000000000"), "Entregado", new Guid("e9f8941f-70e4-4d09-9f2a-7b569b619bf2"), true, new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7212), null },
                    { new Guid("f34c5678-9012-cdef-0123-456789012cdc"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7214), new Guid("00000000-0000-0000-0000-000000000000"), "Devuelto", new Guid("38fe8cf4-4db1-4d67-ad79-09478853f1db"), true, new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7214), null },
                    { new Guid("f34c5678-9012-cdef-0123-456789012cde"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7209), new Guid("00000000-0000-0000-0000-000000000000"), "En Transito", new Guid("bc0b8c32-16bd-4e58-ac30-60c83f76ffc2"), true, new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7209), null }
                });

            migrationBuilder.InsertData(
                table: "rutas",
                columns: new[] { "id", "created_at", "created_by", "destino", "distancia", "is_active", "origen", "ruta_id", "tiempo_estimado", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("81827279-4bc1-4015-9350-2d87ec21dbaf"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(3592), new Guid("00000000-0000-0000-0000-000000000000"), "Guadalajara", 550.5m, true, "Ciudad de México", new Guid("c67f8901-2345-f012-3456-789012345f01"), 6.5m, new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(3578), null },
                    { new Guid("c2f16a60-ee52-454b-9eb3-0a465857a610"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(3597), new Guid("00000000-0000-0000-0000-000000000000"), "Nuevo Laredo", 220.0m, true, "Monterrey", new Guid("a45d6789-0123-def0-1234-567890123def"), 2.8m, new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(3596), null },
                    { new Guid("cd68ce3b-f466-475d-946d-9f704e16e44d"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(3635), new Guid("00000000-0000-0000-0000-000000000000"), "Mérida", 300.2m, true, "Cancún", new Guid("b56e7890-1234-ef01-2345-678901234ef0"), 4.0m, new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(3634), null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_paquete_historial_estado_id",
                table: "paquete_historial",
                column: "estado_id");

            migrationBuilder.CreateIndex(
                name: "ix_paquete_historial_paquete_id",
                table: "paquete_historial",
                column: "paquete_id");

            migrationBuilder.CreateIndex(
                name: "ix_paquetes_estado_id",
                table: "paquetes",
                column: "estado_id");

            migrationBuilder.CreateIndex(
                name: "ix_paquetes_ruta_id",
                table: "paquetes",
                column: "ruta_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "paquete_historial");

            migrationBuilder.DropTable(
                name: "paquetes");

            migrationBuilder.DropTable(
                name: "estados");

            migrationBuilder.DropTable(
                name: "rutas");
        }
    }
}
