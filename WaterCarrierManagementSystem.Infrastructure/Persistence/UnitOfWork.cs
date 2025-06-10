using NHibernate;
using System.Data;
using WaterCarrierManagementSystem.Application.Common.Persistence;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ISession _session;
    private readonly IRepositoryFactory _repositoryFactory;
    private ITransaction? _transaction = null;
    private bool _disposed;

    public UnitOfWork(
        ISession session,
        IRepositoryFactory repositoryFactory)
    {
        _session = session;
        _repositoryFactory = repositoryFactory;
    }

    public void BeginTransaction(IsolationLevel isolation = IsolationLevel.ReadCommitted)
    {
        _transaction = _session.BeginTransaction(isolation);
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(_transaction);
        try
        {
            await _transaction
                .CommitAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            await RollbackAsync(cancellationToken);
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            _transaction?.Dispose();
        }
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(_transaction);
        try
        {
            await _transaction
                .RollbackAsync(cancellationToken);
        }
        finally
        {
            _transaction.Dispose();
            _transaction = null;
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction is null)
            throw new InvalidOperationException(
                "A transaction must be started before saving changes");

        await _session.FlushAsync(cancellationToken);
        return 1; 
    }

    public TRepository GetRepository<TRepository>() where TRepository : class
    {
        return _repositoryFactory.GetRepository<TRepository>();
    }

    public IRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class
    {
        return _repositoryFactory.GetGenericRepository<TEntity>();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _transaction?.Dispose();
            }
            _disposed = true;
        }
    }


}
