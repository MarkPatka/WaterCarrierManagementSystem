using WaterCarrierManagementSystem.Application.Common.Interfaces;
using WaterCarrierManagementSystem.Application.Contractor.Common;

namespace WaterCarrierManagementSystem.Application.Contractor.Commands.DeleteContractor;

public record DeleteContractorCommand(int Id) : ICommand<DeleteContractorResult>;
