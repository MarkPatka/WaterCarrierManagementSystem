using MediatR;
using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Employee.Common;

namespace WaterCarrierManagementSystem.Application.Employee.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler
    : ICommandHandler<CreateEmployeeCommand, CreateEmployeeResult>
{
    Task<CreateEmployeeResult> IRequestHandler<CreateEmployeeCommand, CreateEmployeeResult>.Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
