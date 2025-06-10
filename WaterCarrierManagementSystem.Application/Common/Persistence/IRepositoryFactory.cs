namespace WaterCarrierManagementSystem.Application.Common.Persistence;

public interface IRepositoryFactory
{
    TRepository GetRepository<TRepository>() where TRepository : class;
    IRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class;
}
