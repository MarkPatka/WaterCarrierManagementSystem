
using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Order.Common;

namespace WaterCarrierManagementSystem.Application.Order.Commands.CreateOrder;

public record CreateOrderCommand(Domain.OrderAggregate.Order NewOrder) : ICommand<CreateOrderResult>;
