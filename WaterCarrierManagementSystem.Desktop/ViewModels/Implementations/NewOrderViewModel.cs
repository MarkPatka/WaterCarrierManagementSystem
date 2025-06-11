using System.Collections.ObjectModel;
using WaterCarrierManagementSystem.Desktop.Commands;
using WaterCarrierManagementSystem.Desktop.Commands.Abstract;
using WaterCarrierManagementSystem.Desktop.ViewModels.Interfaces;
using WaterCarrierManagementSystem.Domain.ContractorAggregate;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate;

namespace WaterCarrierManagementSystem.Desktop.ViewModels.Implementations;

public class NewOrderViewModel 
    : ViewModelBase, INewOrderViewModel
{
    public ObservableCollection<string> Employees => [.. _employees];
    public ObservableCollection<string> Contractors => [.. _contractors];
    
    public Employee? SelectedEmployee 
    {
        get => _selectedEmployee;
        set
        {
            Set(ref _selectedEmployee, value);
            OnPropertyChanged();
        }
    }
    public Contractor? SelectedContractor
    {
        get => _selectedContractor;
        set
        {
            Set(ref _selectedContractor, value);
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

    public NewOrderViewModel(ICommandFactory commandFactory)
    {
        _commandFactory = commandFactory;

        _loadEmployees = _commandFactory.GetCommand<LoadEmployeesCommand>();
        _loadEmployees.CommandCompleted += OnEmployeesLoaded;

        _loadContractors = _commandFactory.GetCommand<LoadContractorsCommand>();
        _loadContractors.CommandCompleted += OnContractorsLoaded;

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
            var names = data.Employees
                .Select(e => $"{e.Name.LastName} {e.Name.FirstName} {e.Name.MiddleName}");

            _employees.AddRange(names);
            OnPropertyChanged(nameof(Employees));
        }
    }
    private void OnContractorsLoaded(object? sender, CommandResult<LoadContractorsResult> result)
    {
        if (result.Status == CommandStatus.SUCCESS && result.Value is LoadContractorsResult data)
        {
            var names = data.Contractors
                .Select(c => $"{c.Name}");

            _contractors.AddRange(names);
            OnPropertyChanged(nameof(Contractors));
        }
    }

    private readonly ICommandFactory _commandFactory;
    private readonly LoadEmployeesCommand _loadEmployees;
    private readonly LoadContractorsCommand _loadContractors;

    private readonly List<string> _employees = [];
    private readonly List<string> _contractors = [];

    private Employee? _selectedEmployee;
    private Contractor? _selectedContractor;
    private DateTime _creationDate = DateTime.UtcNow;
    private decimal _amount = 0.00m;
}
