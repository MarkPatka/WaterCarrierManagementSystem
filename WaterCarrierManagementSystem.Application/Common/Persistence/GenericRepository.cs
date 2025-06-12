using NHibernate;
using NHibernate.Linq;
using System.Data;
using System.Linq.Expressions;

namespace WaterCarrierManagementSystem.Application.Common.Persistence;

public class GenericRepository<TEntity> 
    : IRepository<TEntity> where TEntity : class
{
    private readonly ISession _session;
    private ITransaction? _transaction = null;

    public GenericRepository(ISession session)
    {
        _session = session;
    }

    public virtual List<TEntity> GetAll()
    {
        return _session.Query<TEntity>().ToList();
    }

    public virtual async Task<IList<TEntity>> GetAllAsync()
    {
        return await  _session.Query<TEntity>()
            .ToListAsync();
    }
    public virtual async Task<IList<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
    {
        return await _session.Query<TEntity>()
            .Where(predicate).ToListAsync();
    }
    public virtual async Task<IList<TEntity>> GetAll(int pageIndex, int pageSize)
    {
        return await _session.Query<TEntity>()
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(
        object id, CancellationToken cancellationToken = default)
    {
        return await _session
            .GetAsync<TEntity>(id, cancellationToken);
    }

    public async Task CreateAsync(
        TEntity entity, CancellationToken cancellationToken = default)
    {
        var identifier = await _session
            .SaveAsync(entity, cancellationToken);

        _session.Save(entity);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(
        TEntity entity, CancellationToken cancellationToken = default)
    {
        await _session
            .UpdateAsync(entity, cancellationToken);
    }

    public async Task DeleteAsync(
        TEntity entity, CancellationToken cancellationToken = default)
    {
        await _session
            .DeleteAsync(entity, cancellationToken);
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
}
