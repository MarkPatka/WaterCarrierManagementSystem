using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Driver.MySqlConnector;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;
using WaterCarrierManagementSystem.Application.Common.Persistence;
using WaterCarrierManagementSystem.Application.Common.Persistence.Repositories;
using WaterCarrierManagementSystem.Infrastructure.Persistence;
using WaterCarrierManagementSystem.Infrastructure.Persistence.Configurations;
using WaterCarrierManagementSystem.Infrastructure.Persistence.Repositories;

namespace WaterCarrierManagementSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .RegisterRepositories()
            .RegisterNHibernate()
            ;

        return services;
    }

    private static IServiceCollection RegisterNHibernate(this IServiceCollection services)
    {

        services.AddSingleton<ISessionFactory>(provider =>
        {
            var dbSettings = provider
                .GetRequiredService<IOptions<DatabaseSettings>>().Value;
;
            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                    .ConnectionString(dbSettings.ConnectionString)
                    .AdoNetBatchSize(20)
                    .Driver<MySqlConnectorDriver>()
                    .Dialect<MySQL55Dialect>()
                )
                .Mappings(m => 
                {
                    m.FluentMappings
                        .AddFromAssembly(Assembly.GetExecutingAssembly())
                        .Conventions.Add(DefaultCascade.All());
                })
                .ExposeConfiguration(cfg =>
                {
                    cfg.SetProperty(NHibernate.Cfg.Environment.GenerateStatistics, "false");
                    cfg.SetProperty(NHibernate.Cfg.Environment.PrepareSql, "true");
                })
                .BuildSessionFactory();
        });

        services.AddScoped<ISession>(provider =>
        {
            var sessionFactory = provider
                .GetRequiredService<ISessionFactory>();

            var session = sessionFactory.OpenSession();

            session.FlushMode = FlushMode.Commit;

            return session;
        });

        return services;
    }

    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRepositoryFactory, RepositoryFactory>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IContractorRepository, ContractorRepository>();

        return services;
    }
}
