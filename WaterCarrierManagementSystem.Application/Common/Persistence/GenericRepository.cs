using NHibernate;
using NHibernate.Linq;
using System.Linq.Expressions;

namespace WaterCarrierManagementSystem.Application.Common.Persistence;

public class GenericRepository<TEntity> 
    : IRepository<TEntity> where TEntity : class
{
    private readonly ISession _session;

    public GenericRepository(ISession session)
    {
        _session = session;
    }

    public virtual async Task<IList<TEntity>> GetAll()
    {
        return await _session.Query<TEntity>()
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
        await _session
            .SaveAsync(entity, cancellationToken);
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


}
