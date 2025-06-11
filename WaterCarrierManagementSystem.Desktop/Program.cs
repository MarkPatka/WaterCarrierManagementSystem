using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using WaterCarrierManagementSystem.Application;
using WaterCarrierManagementSystem.Desktop.Configurations;
using WaterCarrierManagementSystem.Desktop.ViewModels.Interfaces;
using WaterCarrierManagementSystem.Desktop.Views;
using WaterCarrierManagementSystem.Infrastructure;

namespace WaterCarrierManagementSystem.Desktop;

internal class Program
{
    private const int TimeoutSeconds = 3;

    [STAThread]
    public static void Main(string[] args)
    {
        EnvLoader.Load();

        using var mutex = new Mutex(true, Assembly.GetExecutingAssembly().FullName);
        try
        {
            if (!mutex.WaitOne(TimeSpan.FromSeconds(TimeoutSeconds), true))
            {
                MessageBox.Show(
                    $"Application is already running",
                    "Warning",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else
            {
                using IHost host = CreateHostBuilder().Build();
                SubscribeToDomainEvents();
                RunWpfApplication(host);
            }
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }

    private static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services
                    .AddPresentation()
                    .AddApplication()
                    .AddInfrastructure();
            });
    private static void SubscribeToDomainEvents()
    {
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            Exception ex = (Exception)args.ExceptionObject;

            MessageBox.Show(
                $"An unhandled exception occurred: {ex.Message}",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        };
    }
    private static void RunWpfApplication(IHost host)
    {
        try
        {
            var app = new App();
            app.InitializeComponent();

            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.DataContext = host.Services.GetRequiredService<IMainViewModel>();

            app.Run(mainWindow);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Program error occurred: {ex.Message}",
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

}
