using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Order.Common;

namespace WaterCarrierManagementSystem.Application.Order.Queries.GetOrder;

public record GetOrderQuery(string ContractorName) : IQuery<GetOrderResult>;
