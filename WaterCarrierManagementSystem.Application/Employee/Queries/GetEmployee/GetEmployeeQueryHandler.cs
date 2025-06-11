using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Employee.Common;

namespace WaterCarrierManagementSystem.Application.Employee.Queries.GetEmployee;

public class GetEmployeeQueryHandler
    : IQueryHandler<GetEmployeeQuery, GetEmployeeResult>
{
    public Task<GetEmployeeResult> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
