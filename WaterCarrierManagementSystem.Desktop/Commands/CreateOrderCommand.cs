using WaterCarrierManagementSystem.Application.Common.Persistence;
using WaterCarrierManagementSystem.Application.Common.Persistence.Repositories;
using WaterCarrierManagementSystem.Desktop.Commands.Abstract;
using WaterCarrierManagementSystem.Desktop.ViewModels.Implementations;
using WaterCarrierManagementSystem.Domain.OrderAggregate;

namespace WaterCarrierManagementSystem.Desktop.Commands;

internal class CreateOrderCommand(IOrderRepository orderRepository)
    : AsyncRelayCommand<CreateOrderResult>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public override Func<object?, Task<CommandResult<CreateOrderResult>>> ExecuteCommand => CreateOrder;

    public override Predicate<object?>? CanExecuteCommand => null;

    public override Action<Exception>? ErrorHandler => LogError;

    private async Task<CommandResult<CreateOrderResult>> CreateOrder(object? parameter = null)
    {
        try
        {
            if (parameter is NewOrderViewModel ordervm)
            {

                var createOrderRequest = Order.Create(
                    ordervm.CreationDate,
                    ordervm.Amount,
                    ordervm.employees.FirstOrDefault(e => e.Name.ToString().Equals(ordervm.SelectedEmployeeName)),
                    ordervm.contractors.FirstOrDefault(e => e.Name.ToString().Equals(ordervm.SelectedContractorName)));

                _orderRepository.BeginTransaction();

                await _orderRepository
                    .CreateAsync(createOrderRequest);

                await _orderRepository.CommitAsync();


                await _orderRepository.SaveChangesAsync();

                CreateOrderResult added = new(true);
                return new CommandResult<CreateOrderResult>(added);
            }
            CreateOrderResult fallback = new(false);
            return new CommandResult<CreateOrderResult>(fallback);
        }
        catch (Exception ex)
        {
            ErrorHandler?.Invoke(ex);
            return new CommandResult<CreateOrderResult>(ex);
        }
    }

    private void LogError(Exception message)
    {
        Console.WriteLine(message.Message);
    }
}

public record CreateOrderResult(bool created);
