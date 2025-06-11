using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Employee.Common;

namespace WaterCarrierManagementSystem.Application.Employee.Queries.UpdateEmployee;

public class UpdateEmployeeQueryHandler
    : IQueryHandler<UpdateEmployeeQuery, UpdateEmployeeResult>
{
    public Task<UpdateEmployeeResult> Handle(UpdateEmployeeQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
