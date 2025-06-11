using Sprache;
using System.Windows;
using WaterCarrierManagementSystem.Desktop.Commands.Abstract;
using WaterCarrierManagementSystem.Desktop.ViewModels.Interfaces;
using WaterCarrierManagementSystem.Desktop.Views;
using Windows.ApplicationModel.Wallet;

namespace WaterCarrierManagementSystem.Desktop.Commands;

public class OpenAddTabItemWindowCommand()
    : AsyncRelayCommand<OpenAddTabItemWindowResult>
{

    public override Func<object?, Task<CommandResult<OpenAddTabItemWindowResult>>> ExecuteCommand => OpenWindow;

    public override Predicate<object?>? CanExecuteCommand => null;

    public override Action<Exception>? ErrorHandler => LogError;


    private async Task<CommandResult<OpenAddTabItemWindowResult>> OpenWindow(object? parameter = null)
    {
        try
        {
            string tabName = parameter?.ToString() ?? "";
            if (tabName.Equals("Orders"))
            {
                var view = new NewOrderWindow()
                {
                    Owner = System.Windows.Application.Current.MainWindow
                };
                OpenAddTabItemWindowResult window = new(view);
                return new CommandResult<OpenAddTabItemWindowResult>(window);
            }
            else throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            ErrorHandler?.Invoke(ex);
            return new CommandResult<OpenAddTabItemWindowResult>(ex);
        }
    }

    private void View_Closed(object? sender, EventArgs e)
    {
        if (sender is Window w && w is not null)
        {
            ((Window)sender).Closed -= View_Closed;
        }
    }

    private void LogError(Exception message)
    {
        Console.WriteLine(message.Message);
    }
}

public record OpenAddTabItemWindowResult(Window TabItemWindow);
