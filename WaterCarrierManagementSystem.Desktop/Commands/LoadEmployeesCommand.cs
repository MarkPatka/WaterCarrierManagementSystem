using WaterCarrierManagementSystem.Application.Common.Persistence.Repositories;
using WaterCarrierManagementSystem.Application.Common.Persistence;
using WaterCarrierManagementSystem.Desktop.Commands.Abstract;
using WaterCarrierManagementSystem.Domain.ContractorAggregate;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate;
using WaterCarrierManagementSystem.Infrastructure.Persistence;

namespace WaterCarrierManagementSystem.Desktop.Commands;

public class LoadEmployeesCommand(IEmployeeRepository employeeRepository)
    : AsyncRelayCommand<LoadEmployeesResult>
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public override Func<object?, Task<CommandResult<LoadEmployeesResult>>> ExecuteCommand => LoadAllEmployees;

    public override Predicate<object?>? CanExecuteCommand => null;

    public override Action<Exception>? ErrorHandler => LogError;

    private async Task<CommandResult<LoadEmployeesResult>> LoadAllEmployees(object? parameter = null)
    {
        try
        {

            var data = _employeeRepository.GetAll();
            LoadEmployeesResult result = new(data);

            return new CommandResult<LoadEmployeesResult>(result);
        }
        catch (Exception ex)
        {
            ErrorHandler?.Invoke(ex);
            return new CommandResult<LoadEmployeesResult>(ex);
        }
    }

    private void LogError(Exception message)
    {
        Console.WriteLine(message.Message);
    }

}
public record LoadEmployeesResult(IEnumerable<Employee> Employees);
