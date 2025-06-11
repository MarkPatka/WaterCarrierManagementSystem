
using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Contractor.Common;

namespace WaterCarrierManagementSystem.Application.Contractor.Queries.GetContractor;

public record GetContractorQuery(Domain.ContractorAggregate.Contractor Contractor) : IQuery<GetContractorResult>;

