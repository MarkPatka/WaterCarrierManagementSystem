using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Contractor.Common;

namespace WaterCarrierManagementSystem.Application.Contractor.Queries.GetContractor;

public class GetContractorQueryHandler
    : IQueryHandler<GetContractorQuery, GetContractorResult>
{
    public Task<GetContractorResult> Handle(GetContractorQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
