using System.Windows.Input;

namespace WaterCarrierManagementSystem.Desktop.Commands.Abstract;

public abstract class RelayCommand : ICommand
{
    public abstract Action<object?> ExecuteCommand { get; }
    public abstract Predicate<object?>? CanExecuteCommand { get; }

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object? parameter)
    {
        return CanExecute == null || CanExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        Execute(parameter);
    }
}
