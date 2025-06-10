namespace WaterCarrierManagementSystem.Application.Common.Persistence;

public interface IRepository<T> where T : class
{
    public Task<T?> GetByIdAsync(object id,  CancellationToken cancellationToken = default);
    public Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    public Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
}
