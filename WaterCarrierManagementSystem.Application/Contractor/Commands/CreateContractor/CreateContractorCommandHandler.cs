using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Contractor.Common;

namespace WaterCarrierManagementSystem.Application.Contractor.Commands.CreateContractor;

public class CreateContractorCommandHandler
    : ICommandHandler<CreateContractorCommand, CreateContractorResult>
{
    public Task<CreateContractorResult> Handle(CreateContractorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
