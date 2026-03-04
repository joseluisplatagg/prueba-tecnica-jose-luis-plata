using CleanArchitecture.PracticalTest.Domain.Common;
using CleanArchitecture.PracticalTest.Domain.Interfaces;

namespace CleanArchitecture.PracticalTest.Application.Contracts.Data;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseDomainModel;

    Task<int> CompleteAsync(CancellationToken ct);
}