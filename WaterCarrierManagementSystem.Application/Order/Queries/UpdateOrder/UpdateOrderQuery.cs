using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Order.Common;

namespace WaterCarrierManagementSystem.Application.Order.Queries.UpdateOrder;

public record UpdateOrderQuery(Domain.OrderAggregate.Order UpdatedOrder) : IQuery<UpdateOrderResult>;
