using WaterCarrierManagementSystem.Application.Common.Persistence.Repositories;
using WaterCarrierManagementSystem.Application.Common.Persistence;
using WaterCarrierManagementSystem.Desktop.Commands.Abstract;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate;
using WaterCarrierManagementSystem.Domain.OrderAggregate;

namespace WaterCarrierManagementSystem.Desktop.Commands;

public class LoadOrdersCommand(IOrderRepository orderRepository)
    : AsyncRelayCommand<LoadOrdersResult>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public override Func<object?, Task<CommandResult<LoadOrdersResult>>> ExecuteCommand => LoadAllOrders;

    public override Predicate<object?>? CanExecuteCommand => null;

    public override Action<Exception>? ErrorHandler => LogError;

    private async Task<CommandResult<LoadOrdersResult>> LoadAllOrders(object? parameter = null)
    {
        try
        {
            var data = _orderRepository.GetAll();
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
public record LoadOrdersResult(IEnumerable<Order> Orders);
