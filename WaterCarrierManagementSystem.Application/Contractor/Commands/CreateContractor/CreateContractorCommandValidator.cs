using FluentValidation;

namespace WaterCarrierManagementSystem.Application.Contractor.Commands.CreateContractor;

public class CreateContractorCommandValidator
    : AbstractValidator<CreateContractorCommand>
{
    public CreateContractorCommandValidator()
    {
        RuleFor(x => x.Contractor).NotNull();
    }
}
