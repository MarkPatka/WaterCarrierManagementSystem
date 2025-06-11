using Microsoft.Extensions.DependencyInjection;
using WaterCarrierManagementSystem.Desktop.ViewModels.Interfaces;

namespace WaterCarrierManagementSystem.Desktop.ViewModels.Implementations;

public class ViewModelFactory(IServiceProvider serviceProvider) : IViewModelFactory
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    
    public T GetViewModel<T>() where T : notnull, IBaseViewModel
    {
        var vm = _serviceProvider.GetRequiredService<T>();
        return vm;
    }
}
