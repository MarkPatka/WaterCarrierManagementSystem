using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Employee.Common;

namespace WaterCarrierManagementSystem.Application.Employee.Queries.UpdateEmployee;

public record UpdateEmployeeQuery(Domain.EmplyeeAggregate.Employee Employee) : IQuery<UpdateEmployeeResult>;
