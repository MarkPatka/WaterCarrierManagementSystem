using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Order.Common;

namespace WaterCarrierManagementSystem.Application.Order.Queries.GetOrder;

public class GetOrderQueryHandler
    : IQueryHandler<GetOrderQuery, GetOrderResult>
{
    public Task<GetOrderResult> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
