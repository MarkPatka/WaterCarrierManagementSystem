using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Order.Common;

namespace WaterCarrierManagementSystem.Application.Order.Commands.DeleteOrder;

public record DeleteOrderCommand(int Id) : ICommand<DeleteOrderResult>;
