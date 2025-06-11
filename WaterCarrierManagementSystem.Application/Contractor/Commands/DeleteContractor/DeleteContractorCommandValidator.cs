using FluentValidation;

namespace WaterCarrierManagementSystem.Application.Contractor.Commands.DeleteContractor;

public class DeleteContractorCommandValidator
    : AbstractValidator<DeleteContractorCommand>
{
    public DeleteContractorCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
