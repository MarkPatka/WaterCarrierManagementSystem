using FluentValidation;

namespace WaterCarrierManagementSystem.Application.Employee.Queries.GetEmployee;

public class GetEmployeeQueryValidator
    : AbstractValidator<GetEmployeeQuery>
{
    public GetEmployeeQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
