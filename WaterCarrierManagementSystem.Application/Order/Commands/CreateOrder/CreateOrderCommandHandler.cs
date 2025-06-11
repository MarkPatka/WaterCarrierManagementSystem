using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Order.Common;

namespace WaterCarrierManagementSystem.Application.Order.Commands.CreateOrder;

public class CreateOrderCommandHandler
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
