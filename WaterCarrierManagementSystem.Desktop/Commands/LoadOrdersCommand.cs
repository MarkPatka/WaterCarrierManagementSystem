using WaterCarrierManagementSystem.Application.Common.Persistence.Repositories;
using WaterCarrierManagementSystem.Application.Common.Persistence;
using WaterCarrierManagementSystem.Desktop.Commands.Abstract;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate;
using WaterCarrierManagementSystem.Domain.OrderAggregate;

namespace WaterCarrierManagementSystem.Desktop.Commands;

public class LoadOrdersCommand(IUnitOfWork unitOfWork)
    : AsyncRelayCommand<LoadOrdersResult>
{
    private readonly IUnitOfWork _contractorsRepositoryUnit = unitOfWork;

    public override Func<object?, Task<CommandResult<LoadOrdersResult>>> ExecuteCommand => LoadAllContractors;

    public override Predicate<object?>? CanExecuteCommand => null;

    public override Action<Exception>? ErrorHandler => LogError;

    private async Task<CommandResult<LoadOrdersResult>> LoadAllContractors(object? parameter = null)
    {
        try
        {
            var repository = (GenericRepository<Order>)_contractorsRepositoryUnit
                .GetGenericRepository<IOrderRepository>();

            var data = await repository.GetAll();
            LoadOrdersResult result = new(data);

            return new CommandResult<LoadOrdersResult>(result);
        }
        catch (Exception ex)
        {
            ErrorHandler?.Invoke(ex);
            return new CommandResult<LoadOrdersResult>(ex);
        }
    }

    private void LogError(Exception message)
    {
        Console.WriteLine(message.Message);
    }

}
public record LoadOrdersResult(IEnumerable<Order> Employees);
