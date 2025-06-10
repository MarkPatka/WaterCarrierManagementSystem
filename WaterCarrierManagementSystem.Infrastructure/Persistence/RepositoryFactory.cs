using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using WaterCarrierManagementSystem.Application.Common.Persistence;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence;

public class RepositoryFactory : IRepositoryFactory
{
    private readonly ISession _session;
    private readonly IServiceProvider _serviceProvider;

    public RepositoryFactory(ISession session, IServiceProvider serviceProvider)
    {
        _session = session;
        _serviceProvider = serviceProvider;
    }

    public TRepository GetRepository<TRepository>() 
        where TRepository : class
    {
        var repo = _serviceProvider.GetService<TRepository>();
        if (repo is not null) return repo;

        throw new InvalidOperationException($"Repository {typeof(TRepository).Name} is not registered");
    }

    public IRepository<TEntity> GetGenericRepository<TEntity>()
        where TEntity : class
    {
        return new GenericRepository<TEntity>(_session);
    }
}
