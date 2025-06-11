using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Order.Common;

namespace WaterCarrierManagementSystem.Application.Order.Commands.DeleteOrder;

public class DeleteOrderCommandHandler
    : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    public Task<DeleteOrderResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
