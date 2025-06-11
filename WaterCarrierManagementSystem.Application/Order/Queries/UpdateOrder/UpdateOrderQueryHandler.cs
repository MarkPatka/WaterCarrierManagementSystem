using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Order.Common;

namespace WaterCarrierManagementSystem.Application.Order.Queries.UpdateOrder;

public class UpdateOrderQueryHandler
    : IQueryHandler<UpdateOrderQuery, UpdateOrderResult>
{
    public Task<UpdateOrderResult> Handle(UpdateOrderQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
