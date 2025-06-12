using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using WaterCarrierManagementSystem.Desktop.Commands;
using WaterCarrierManagementSystem.Desktop.Commands.Abstract;
using WaterCarrierManagementSystem.Desktop.ViewModels.Implementations;
using WaterCarrierManagementSystem.Desktop.ViewModels.Interfaces;
using WaterCarrierManagementSystem.Desktop.Views;
using WaterCarrierManagementSystem.Infrastructure.Persistence.Configurations;

namespace WaterCarrierManagementSystem.Desktop;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services
            .AddConfiguration()
            .RegisterCommands()
            .RegisterViewModels()
            .RegisterViews()
            ;

        return services;
    }

    public static IServiceCollection RegisterViews(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();

        services.AddTransient<NewContractorWindow>();
        services.AddTransient<NewEmployeeWindow>();
        services.AddTransient<NewOrderWindow>();

        return services;
    }
    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services
            .AddTransient<IViewModelFactory, ViewModelFactory>();

        services
            .AddSingleton<IMainViewModel, MainViewModel>();

        services
            .AddTransient<INewOrderViewModel, NewOrderViewModel>()
            .AddTransient<INewEmployeeViewModel, NewEmployeeViewModel>()
            .AddTransient<INewContractorViewModel, NewContractorViewModel>();


        return services;
    }
    private static IServiceCollection RegisterCommands(this IServiceCollection services)
    {
        services
            .AddTransient<ICommandFactory, CommandFactory>();


        services
            .AddTransient<CreateOrderCommand>()
            .AddTransient<LoadContractorsCommand>()
            .AddTransient<LoadEmployeesCommand>()
            .AddTransient<LoadOrdersCommand>()
            .AddTransient<OpenAddTabItemWindowCommand>()
            ;

        return services;
    }
    private static IServiceCollection AddConfiguration(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        services.AddSingleton<IConfiguration>(configuration);

        string host = Environment.GetEnvironmentVariable("MYSQL_HOST")
            ?? throw new ArgumentNullException(nameof(Environment.GetEnvironmentVariable));

        int port = Convert.ToInt32(Environment.GetEnvironmentVariable("MYSQL_TCP_PORT"));

        string user = Environment.GetEnvironmentVariable("MYSQL_USER")
            ?? throw new ArgumentNullException(nameof(Environment.GetEnvironmentVariable));

        string pass = Environment.GetEnvironmentVariable("MYSQL_PASSWORD")
            ?? throw new ArgumentNullException(nameof(Environment.GetEnvironmentVariable));

        string name = Environment.GetEnvironmentVariable("MYSQL_DATABASE")
            ?? throw new ArgumentNullException(nameof(Environment.GetEnvironmentVariable));

        services.Configure<DatabaseSettings>(options =>
        {
            options.DB_HOST = host;
            options.DB_PORT = port;
            options.DB_USER = user;
            options.DB_NAME = name;
            options.DB_PASSWORD = pass;
        });

        return services;
    }
}
