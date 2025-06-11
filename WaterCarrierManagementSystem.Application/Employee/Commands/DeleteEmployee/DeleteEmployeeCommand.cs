using System.Windows.Input;
using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Employee.Common;

namespace WaterCarrierManagementSystem.Application.Employee.Commands.DeleteEmployee;

public record DeleteEmployeeCommand(int Id) : ICommand<DeleteEmployeeResult>;
