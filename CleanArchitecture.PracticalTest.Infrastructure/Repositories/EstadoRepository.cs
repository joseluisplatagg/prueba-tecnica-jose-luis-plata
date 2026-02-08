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
    public class EstadoRepository : IEstadoRepository
    {
        public Task<Estado> AddAsync(Estado entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Estado>> AddRangeAsync(IEnumerable<Estado> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(ISpecification<Estado> spec)
        {
            throw new NotImplementedException();
        }

        public void Delete(Estado entity)
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

        public void DeleteRange(IEnumerable<Estado> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(Expression<Func<Estado, bool>> predicate, List<string>? includes = null, EntityStatusFilter filter = EntityStatusFilter.OnlyActive)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Estado>> GetAllAsync(List<string>? includes = null, bool disableTracking = true, EntityStatusFilter filter = EntityStatusFilter.OnlyActive)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Estado>> GetAllWithSpecAsync(ISpecification<Estado> spec)
        {
            throw new NotImplementedException();
        }

        public Task<Estado?> GetByIdAsync(Guid id, List<string>? includes = null, EntityStatusFilter filter = EntityStatusFilter.OnlyActive)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Estado>> GetListAsync(Expression<Func<Estado, bool>> predicate, Func<IQueryable<Estado>, IOrderedQueryable<Estado>>? orderBy = null, List<string>? includes = null, bool disableTracking = true, EntityStatusFilter filter = EntityStatusFilter.OnlyActive)
        {
            throw new NotImplementedException();
        }

        public Task<Estado?> GetWithSpecAsync(ISpecification<Estado> spec)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(Estado entity)
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

        public void SoftDeleteRange(IEnumerable<Estado> entities)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteRangeAsync(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Estado Update(Estado entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Estado> UpdateRange(IEnumerable<Estado> entities)
        {
            throw new NotImplementedException();
        }
    }
}
