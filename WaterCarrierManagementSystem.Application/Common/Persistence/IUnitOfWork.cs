using System.Data;

namespace WaterCarrierManagementSystem.Application.Common.Persistence;

public interface IUnitOfWork : IDisposable
{
    void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    Task CommitAsync(CancellationToken cancellationToken = default);
    Task RollbackAsync(CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    public TRepository GetRepository<TRepository>()
        where TRepository : class;

    public IRepository<TEntity> GetGenericRepository<TEntity>()
        where TEntity : class;
}

