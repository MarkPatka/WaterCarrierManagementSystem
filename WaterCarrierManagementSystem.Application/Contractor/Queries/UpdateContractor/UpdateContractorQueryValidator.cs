using FluentValidation;

namespace WaterCarrierManagementSystem.Application.Contractor.Queries.UpdateContractor;

public class UpdateContractorQueryValidator
    : AbstractValidator<UpdateContractorQuery>
{
    public UpdateContractorQueryValidator()
    {
        RuleFor(x => x.Contractor).NotNull();
    }
}
