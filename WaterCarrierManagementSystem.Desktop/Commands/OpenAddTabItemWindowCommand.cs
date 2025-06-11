using Sprache;
using System.Windows;
using WaterCarrierManagementSystem.Desktop.Commands.Abstract;
using WaterCarrierManagementSystem.Desktop.ViewModels.Implementations;
using WaterCarrierManagementSystem.Desktop.ViewModels.Interfaces;
using WaterCarrierManagementSystem.Desktop.Views;
using Windows.ApplicationModel.Wallet;

namespace WaterCarrierManagementSystem.Desktop.Commands;

public class OpenAddTabItemWindowCommand(IViewModelFactory viewModelFactory)
    : AsyncRelayCommand<OpenAddTabItemWindowResult>
{
    private readonly IViewModelFactory _viewModelFactory = viewModelFactory;


    public override Func<object?, Task<CommandResult<OpenAddTabItemWindowResult>>> ExecuteCommand => OpenWindow;

    public override Predicate<object?>? CanExecuteCommand => null;

    public override Action<Exception>? ErrorHandler => LogError;


    private async Task<CommandResult<OpenAddTabItemWindowResult>> OpenWindow(object? parameter = null)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(parameter);
            string tabName = parameter.ToString()!;

            var window = tabName switch
            {
                "Orders" => new OpenAddTabItemWindowResult(new NewOrderWindow 
                { 
                    Owner = System.Windows.Application.Current.MainWindow,
                    DataContext = _viewModelFactory.GetViewModel<INewOrderViewModel>()
                }),
                "Employees" => new OpenAddTabItemWindowResult(new NewEmployeeWindow 
                { 
                    Owner = System.Windows.Application.Current.MainWindow,
                    DataContext = _viewModelFactory.GetViewModel<INewEmployeeViewModel>()
                }),
                "Contractors" => new OpenAddTabItemWindowResult(new NewContractorWindow 
                { 
                    Owner = System.Windows.Application.Current.MainWindow,
                    DataContext = _viewModelFactory.GetViewModel<INewContractorViewModel>()

                }),
                _ => throw new ArgumentException($"Unresolved Tab Item Name {tabName}")
            };
            return new CommandResult<OpenAddTabItemWindowResult>(window);
        }
        catch (Exception ex)
        {
            ErrorHandler?.Invoke(ex);
            return new CommandResult<OpenAddTabItemWindowResult>(ex);
        }
    }

    private void LogError(Exception message)
    {
        Console.WriteLine(message.Message);
    }
}

public record OpenAddTabItemWindowResult(Window TabItemWindow);
