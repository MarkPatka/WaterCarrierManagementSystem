using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Contractors.Common;

namespace WaterCarrierManagementSystem.Application.Contractor.Queries.UpdateContractor;

public record UpdateContractorQuery(Domain.ContractorAggregate.Contractor Contractor) : IQuery<UpdateContractorResult>;

