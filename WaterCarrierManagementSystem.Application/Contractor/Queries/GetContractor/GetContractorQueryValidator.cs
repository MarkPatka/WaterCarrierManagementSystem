using FluentValidation;

namespace WaterCarrierManagementSystem.Application.Contractor.Queries.GetContractor;

public class GetContractorQueryValidator
    : AbstractValidator<GetContractorQuery>
{
    public GetContractorQueryValidator()
    {
        RuleFor(x => x.Contractor).NotNull();
    }
}
