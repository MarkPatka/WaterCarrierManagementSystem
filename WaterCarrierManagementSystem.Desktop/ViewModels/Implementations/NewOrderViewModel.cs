using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WaterCarrierManagementSystem.Desktop.Commands;
using WaterCarrierManagementSystem.Desktop.Commands.Abstract;
using WaterCarrierManagementSystem.Desktop.ViewModels.Interfaces;
using WaterCarrierManagementSystem.Domain.ContractorAggregate;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate;
using WaterCarrierManagementSystem.Domain.OrderAggregate;

namespace WaterCarrierManagementSystem.Desktop.ViewModels.Implementations;

public class NewOrderViewModel 
    : ViewModelBase, INewOrderViewModel
{

    public List<Employee> employees = [];
    public List<Contractor> contractors = [];


    public ObservableCollection<string> Employees
    {
        get => _employees;
        set
        {
            _employees = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<string> Contractors 
    {
        get => _contractors;
        set
        {
            _contractors = value;
            OnPropertyChanged();
        }
    }
    
    public string? SelectedEmployeeName 
    {
        get => _selectedEmployeeName;
        set
        {
            Set(ref _selectedEmployeeName, value);
            OnPropertyChanged();
        }
    }
    public string? SelectedContractorName
    {
        get => _selectedContractorName;
        set
        {
            Set(ref _selectedContractorName, value);
            OnPropertyChanged();
        }
    }

    public DateTime CreationDate 
    {
        get => _creationDate;
        set
        {
            if (value < DateTime.UtcNow)
            {
                throw new ArgumentException("You cannot create new order with the past date.");
            }

            Set(ref _creationDate, value);
            OnPropertyChanged();
        }
    }
    public decimal Amount
    {
        get => _amount;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Order amount must be non-negative decimal number");
            }

            Set(ref _amount, value);
            OnPropertyChanged();
        }
    }

    public ICommand CreateNewOrderCommand => _createOrder;

    public NewOrderViewModel(ICommandFactory commandFactory)
    {
        _commandFactory = commandFactory;

        _loadEmployees = _commandFactory.GetCommand<LoadEmployeesCommand>();
        _loadEmployees.CommandCompleted += OnEmployeesLoaded;

        _loadContractors = _commandFactory.GetCommand<LoadContractorsCommand>();
        _loadContractors.CommandCompleted += OnContractorsLoaded;

        _createOrder = _commandFactory.GetCommand<CreateOrderCommand>();
        _createOrder.CommandCompleted += OnOrderCreated;

        LoadData();
    }

    private void LoadData()
    {
        _loadEmployees.Execute(null);
        _loadContractors.Execute(null);
    }

    private void OnEmployeesLoaded(object? sender, CommandResult<LoadEmployeesResult> result)
    {
        if (result.Status == CommandStatus.SUCCESS && result.Value is LoadEmployeesResult data)
        {
            employees.AddRange(data.Employees);

            var names = data.Employees
                .Select(e => $"{e.Name.LastName} {e.Name.FirstName} {e.Name.MiddleName}");

            _employees = [.. names];
            OnPropertyChanged(nameof(Employees));
        }
    }
    private void OnContractorsLoaded(object? sender, CommandResult<LoadContractorsResult> result)
    {
        if (result.Status == CommandStatus.SUCCESS && result.Value is LoadContractorsResult data)
        {
            contractors.AddRange(data.Contractors);

            var names = data.Contractors
                .Select(c => $"{c.Name}");

            _contractors = [.. names];

            OnPropertyChanged(nameof(Contractors));
        }
    }

    private void OnOrderCreated(object? sender, CommandResult<CreateOrderResult> result)
    {
        if (result.Status == CommandStatus.SUCCESS && result.Value is CreateOrderResult data)
        {
            MessageBox.Show("New order has been created");
        }
    }


    private readonly ICommandFactory _commandFactory;
    private readonly LoadEmployeesCommand _loadEmployees;
    private readonly LoadContractorsCommand _loadContractors;
    private readonly CreateOrderCommand _createOrder;
    
    private ObservableCollection<string> _employees = [];
    private ObservableCollection<string> _contractors = [];

    private string? _selectedEmployeeName;
    private string? _selectedContractorName;
    private DateTime _creationDate = DateTime.UtcNow;
    private decimal _amount = 0.00m;
}
