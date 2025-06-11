using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Contractor.Common;

namespace WaterCarrierManagementSystem.Application.Contractor.Commands.DeleteContractor;

public class DeleteContractorCommandHandler
    : ICommandHandler<DeleteContractorCommand, DeleteContractorResult>
{
    public Task<DeleteContractorResult> Handle(DeleteContractorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
