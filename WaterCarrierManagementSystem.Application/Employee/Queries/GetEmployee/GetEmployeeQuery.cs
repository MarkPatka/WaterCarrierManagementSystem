using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Employee.Common;

namespace WaterCarrierManagementSystem.Application.Employee.Queries.GetEmployee;

public record GetEmployeeQuery(int Id) : IQuery<GetEmployeeResult>;
