using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Employee.Common;

namespace WaterCarrierManagementSystem.Application.Employee.Commands.DeleteEmployee;

public class DeleteEmployeeCommandHandler
    : ICommandHandler<DeleteEmployeeCommand, DeleteEmployeeResult>
{
    public Task<DeleteEmployeeResult> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
