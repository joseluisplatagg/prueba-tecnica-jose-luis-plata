using CleanArchitecture.PracticalTest.Domain.Common;
using CleanArchitecture.PracticalTest.Domain.Entities;
using CleanArchitecture.PracticalTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Infrastructure.Repositories
{
    public class RutaRepository : IRutaRepository
    {
        public Task<Ruta> AddAsync(Ruta entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ruta>> AddRangeAsync(IEnumerable<Ruta> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(ISpecification<Ruta> spec)
        {
            throw new NotImplementedException();
        }

        public void Delete(Ruta entity)
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

        public void DeleteRange(IEnumerable<Ruta> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(Expression<Func<Ruta, bool>> predicate, List<string>? includes = null, EntityStatusFilter filter = EntityStatusFilter.OnlyActive)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ruta>> GetAllAsync(List<string>? includes = null, bool disableTracking = true, EntityStatusFilter filter = EntityStatusFilter.OnlyActive)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ruta>> GetAllWithSpecAsync(ISpecification<Ruta> spec)
        {
            throw new NotImplementedException();
        }

        public Task<Ruta?> GetByIdAsync(Guid id, List<string>? includes = null, EntityStatusFilter filter = EntityStatusFilter.OnlyActive)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ruta>> GetListAsync(Expression<Func<Ruta, bool>> predicate, Func<IQueryable<Ruta>, IOrderedQueryable<Ruta>>? orderBy = null, List<string>? includes = null, bool disableTracking = true, EntityStatusFilter filter = EntityStatusFilter.OnlyActive)
        {
            throw new NotImplementedException();
        }

        public Task<Ruta?> GetWithSpecAsync(ISpecification<Ruta> spec)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(Ruta entity)
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

        public void SoftDeleteRange(IEnumerable<Ruta> entities)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteRangeAsync(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Ruta Update(Ruta entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ruta> UpdateRange(IEnumerable<Ruta> entities)
        {
            throw new NotImplementedException();
        }
    }
}
