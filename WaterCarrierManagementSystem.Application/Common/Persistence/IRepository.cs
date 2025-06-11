using System.Linq.Expressions;
using WaterCarrierManagementSystem.Domain.Common.Abstract;

namespace WaterCarrierManagementSystem.Application.Common.Persistence;

public interface IRepository<T> where T : class
{
    public Task<IList<T>> GetAll();
    public Task<IList<T>> GetAll(Expression<Func<T, bool>> predicate);
    public Task<IList<T>> GetAll(int pageIndex, int pageSize);


    public Task<T?> GetByIdAsync(object id,  CancellationToken cancellationToken = default);
    public Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    public Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
}
