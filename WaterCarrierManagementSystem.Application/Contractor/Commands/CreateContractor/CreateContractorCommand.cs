using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Contractor.Common;

namespace WaterCarrierManagementSystem.Application.Contractor.Commands.CreateContractor;

public record CreateContractorCommand(Domain.ContractorAggregate.Contractor Contractor)
    : ICommand<CreateContractorResult>;


