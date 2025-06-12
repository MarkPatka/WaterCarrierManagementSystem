using Sprache;
using System.Collections.ObjectModel;
using System.Windows;
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

    public ICommand OpenAddTabItemCommand => _openAddTabItemWindow;
    public MainViewModel(ICommandFactory commandFactory)
    {
        _commandFactory = commandFactory;

        _openAddTabItemWindow = _commandFactory.GetCommand<OpenAddTabItemWindowCommand>();
        _openAddTabItemWindow.CommandCompleted += OnTabItemOpened;

        _loadEmployees = _commandFactory.GetCommand<LoadEmployeesCommand>();
        _loadEmployees.CommandCompleted += OnEmployeesLoaded;

        _loadContractors = _commandFactory.GetCommand<LoadContractorsCommand>();
        _loadContractors.CommandCompleted += OnContractorsLoaded;

        _loadOrders = _commandFactory.GetCommand<LoadOrdersCommand>();
        _loadOrders.CommandCompleted += OnOrdersLoaded;


        LoadData();
    }

    private void LoadData()
    {
        _loadEmployees.Execute(null);
        _loadContractors.Execute(null);
        _loadOrders.Execute(null);  
    }

    private void OnTabItemOpened(object? sender, CommandResult<OpenAddTabItemWindowResult> result )
    {
        if (result.Status == CommandStatus.SUCCESS && result.Value is OpenAddTabItemWindowResult window)
        {
            window.TabItemWindow.Show();
        }
    }
    private void OnEmployeesLoaded(object? sender, CommandResult<LoadEmployeesResult> result)
    {
        if (result.Status == CommandStatus.SUCCESS && result.Value is LoadEmployeesResult data)
        {
            foreach (var model in data.Employees)
            {
                _employees.Add(new EmployeeModel(
                    Name:      model.Name.ToString(),
                    Position:  model.Position.Name,
                    BirthDate: model.BirthDate));
            }
            OnPropertyChanged(nameof(Employees));
        }
    }
    private void OnContractorsLoaded(object? sender, CommandResult<LoadContractorsResult> result)
    {
        if (result.Status == CommandStatus.SUCCESS && result.Value is LoadContractorsResult data)
        {
            foreach (var model in data.Contractors)
            {
                _contractors.Add(new ContractorModel(
                    model.Name, 
                    model.Inn.Value,
                    model.Curator.Name.ToString()));
            }
            OnPropertyChanged(nameof(Contractors));
        }
    }

    private void OnOrdersLoaded(object? sender, CommandResult<LoadOrdersResult> result)
    {
        if (result.Status == CommandStatus.SUCCESS && result.Value is LoadOrdersResult data)
        {
            foreach (var model in data.Orders)
            {
                _orders.Add(new OrderModel(
                    model.Id.Value,
                    model.Amount,
                    model.OrderDateTime,
                    model.Employee.Name.ToString(),
                    model.Contractor.Name));
            }
            OnPropertyChanged(nameof(Orders));
        }
    }


    private readonly ICommandFactory _commandFactory;
    private readonly OpenAddTabItemWindowCommand _openAddTabItemWindow;
    private readonly LoadEmployeesCommand _loadEmployees;
    private readonly LoadContractorsCommand _loadContractors;
    private readonly LoadOrdersCommand _loadOrders;

    private string _searchText = string.Empty;
    private ObservableCollection<ContractorModel> _contractors = [];
    private ObservableCollection<EmployeeModel> _employees = [];
    private ObservableCollection<OrderModel> _orders = [];
}
