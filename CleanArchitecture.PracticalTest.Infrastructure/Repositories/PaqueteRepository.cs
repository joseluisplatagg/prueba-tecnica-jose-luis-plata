using CleanArchitecture.PracticalTest.Application.Contracts.Data;
using CleanArchitecture.PracticalTest.Domain.Common;
using CleanArchitecture.PracticalTest.Domain.Entities;
using CleanArchitecture.PracticalTest.Domain.Interfaces;
using CleanArchitecture.PracticalTest.Infrastructure.Data;
using CleanArchitecture.PracticalTest.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Infrastructure.Repositories
{
    public class PaqueteRepository(ContextDb dbContext) : BaseRepository<Paquete>(dbContext), IPaqueteRepository
    {
        public async Task<Paquete> AddAsync(Paquete entity)
        {
            await dbContext.Paquetes.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public Task<IEnumerable<Paquete>> AddRangeAsync(IEnumerable<Paquete> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AsignRoute(Guid idPaquete, Guid newEstado, Guid rutaId)
        {
            return await dbContext.Paquetes
                .Where(p => p.PaqueteId == idPaquete)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(p => p.RutaId, rutaId)
                    .SetProperty(p => p.EstadoId, newEstado)
                    .SetProperty(p => p.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(p => p.UpdatedBy, new Guid())
                    );
                
        }

        public Task<int> CountAsync(Domain.Interfaces.ISpecification<Paquete> spec)
        {
            throw new NotImplementedException();
        }

        public void Delete(Paquete entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<Paquete> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(Expression<Func<Paquete, bool>> predicate, List<string>? includes = null, EntityStatusFilter filter = EntityStatusFilter.OnlyActive)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Paquete>> GetAllAsync(List<string>? includes = null, bool disableTracking = true, EntityStatusFilter filter = EntityStatusFilter.OnlyActive)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Paquete>> GetAllWithSpecAsync(Domain.Interfaces.ISpecification<Paquete> spec)
        {
            throw new NotImplementedException();
        }

        public async Task<Paquete?> GetByIdAsync(Guid id, List<string>? includes = null, EntityStatusFilter filter = EntityStatusFilter.OnlyActive)
        {
            return await dbContext.Paquetes.FindAsync(id, includes, filter);
        }

        public Task<IEnumerable<Paquete>> GetListAsync(Expression<Func<Paquete, bool>> predicate, Func<IQueryable<Paquete>, IOrderedQueryable<Paquete>>? orderBy = null, List<string>? includes = null, bool disableTracking = true, EntityStatusFilter filter = EntityStatusFilter.OnlyActive)
        {
            throw new NotImplementedException();
        }

        public async Task<Paquete?> GetPaqueteHistorial(Guid id)
        {
            return await _dbSet
                .Include(p => p.Historial)
                .OrderByDescending(p => p.Historial.Select(h => h.CreatedAt))
                .FirstOrDefaultAsync(p => p.PaqueteId == id);
        }

        public Task<Paquete?> GetWithSpecAsync(Domain.Interfaces.ISpecification<Paquete> spec)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(Paquete entity)
        {
            throw new NotImplementedException();
        }

        public void SoftDeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SoftDeleteRange(IEnumerable<Paquete> entities)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteRangeAsync(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<Paquete> Update(Paquete entity)
        {
            var paquete = await dbContext.Paquetes.FindAsync(entity.PaqueteId);
            if(paquete != null)
            {
                paquete.EstadoId = entity.EstadoId;
                await dbContext.SaveChangesAsync();
            }
            return entity;
        }

        public IEnumerable<Paquete> UpdateRange(IEnumerable<Paquete> entities)
        {
            throw new NotImplementedException();
        }
    }
}
