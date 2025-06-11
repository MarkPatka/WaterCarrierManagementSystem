using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Contractors.Common;

namespace WaterCarrierManagementSystem.Application.Contractor.Queries.UpdateContractor;

public class UpdateContractorQueryHandler
    : IQueryHandler<UpdateContractorQuery, UpdateContractorResult>
{
    public Task<UpdateContractorResult> Handle(UpdateContractorQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
