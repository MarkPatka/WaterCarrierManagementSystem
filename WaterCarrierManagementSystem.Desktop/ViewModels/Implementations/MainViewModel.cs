using Sprache;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WaterCarrierManagementSystem.Desktop.Commands;
using WaterCarrierManagementSystem.Desktop.Commands.Abstract;
using WaterCarrierManagementSystem.Desktop.Models;
using WaterCarrierManagementSystem.Desktop.ViewModels.Interfaces;

namespace WaterCarrierManagementSystem.Desktop.ViewModels.Implementations;

public class MainViewModel : ViewModelBase, IMainViewModel
{
    public static string Title => "Watercarrier Management System";


    public ObservableCollection<ContractorModel> Contractors 
    {
        get => _contractors;
        set
        {
            _contractors = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<EmployeeModel> Employees
    {
        get => _employees;
        set
        {
            _employees = value;
            OnPropertyChanged();
}
    }
    public ObservableCollection<OrderModel> Orders
    {
        get => _orders;
        set
        {
            _orders = value;
            OnPropertyChanged();
        }
    }

    public string SearchText
    {
        get => _searchText;
        set
        {
            _searchText = value;
            OnPropertyChanged();
        }
    }

    public ICommand OpenAddTabItemCommand => _openAddTabItemWindowCommand;

    public MainViewModel(ICommandFactory commandFactory)
    {
        _commandFactory = commandFactory;

        _openAddTabItemWindowCommand = _commandFactory.GetCommand<OpenAddTabItemWindowCommand>();
        _openAddTabItemWindowCommand.CommandCompleted += OnTabItemOpened;

    }

    private void OnTabItemOpened(object? sender, CommandResult<OpenAddTabItemWindowResult> result )
    {
        if (result.Status == CommandStatus.SUCCESS && result.Value is OpenAddTabItemWindowResult window)
        {
            window.TabItemWindow.Show();
        }
    }


    private readonly ICommandFactory _commandFactory;
    private readonly OpenAddTabItemWindowCommand _openAddTabItemWindowCommand;
    
    private string _searchText = string.Empty;
    private ObservableCollection<ContractorModel> _contractors = [];
    private ObservableCollection<EmployeeModel> _employees = [];
    private ObservableCollection<OrderModel> _orders = [];
}
