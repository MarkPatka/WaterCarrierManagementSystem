using NHibernate;
using System.Data;
using System.Linq.Expressions;
using WaterCarrierManagementSystem.Domain.Common.Abstract;

namespace WaterCarrierManagementSystem.Application.Common.Persistence;

public interface IRepository<T> where T : class
{
    public Task<IList<T>> GetAllAsync();
    public Task<IList<T>> GetAll(Expression<Func<T, bool>> predicate);
    public Task<IList<T>> GetAll(int pageIndex, int pageSize);
    public List<T> GetAll();

    public Task<T?> GetByIdAsync(object id,  CancellationToken cancellationToken = default);
    public Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    public Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

    public void BeginTransaction(IsolationLevel isolation = IsolationLevel.ReadCommitted);
    public Task CommitAsync(CancellationToken cancellationToken = default);
    public Task RollbackAsync(CancellationToken cancellationToken = default);
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}
