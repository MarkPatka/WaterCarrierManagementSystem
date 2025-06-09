using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
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
            .RegisterViewModels()
            .RegisterViews()
            ;

        return services;
    }

    public static IServiceCollection RegisterViews(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        return services;
    }
    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddSingleton<IMainViewModel, MainViewModel>();
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
            DatabaseSettings.Create(options));

        return services;
    }
}
