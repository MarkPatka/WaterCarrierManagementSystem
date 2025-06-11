using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Employee.Common;

namespace WaterCarrierManagementSystem.Application.Employee.Commands.CreateEmployee;

public record CreateEmployeeCommand(Domain.EmplyeeAggregate.Employee Employee) : ICommand<CreateEmployeeResult>;
