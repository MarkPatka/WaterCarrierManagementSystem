using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using WaterCarrierManagementSystem.Desktop.Commands.Abstract;

namespace WaterCarrierManagementSystem.Wpf.Commands;

public class CommandFactory(IServiceProvider serviceProvider) : ICommandFactory
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public T GetCommand<T>() where T : notnull, ICommand
    {
        var service = _serviceProvider.GetRequiredService<T>();
        return service;
    }
}
