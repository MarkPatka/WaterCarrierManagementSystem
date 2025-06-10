using NHibernate;

namespace WaterCarrierManagementSystem.Application.Common.Persistence;

public class GenericRepository<TEntity> 
    : IRepository<TEntity> where TEntity : class
{
    private readonly ISession _session;

    public GenericRepository(ISession session)
    {
        _session = session;
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
