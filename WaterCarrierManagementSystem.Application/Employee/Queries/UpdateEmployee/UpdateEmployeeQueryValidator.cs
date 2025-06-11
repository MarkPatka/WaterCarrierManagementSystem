
using FluentValidation;

namespace WaterCarrierManagementSystem.Application.Employee.Queries.UpdateEmployee;

public class UpdateEmployeeQueryValidator
    : AbstractValidator<UpdateEmployeeQuery>
{
    public UpdateEmployeeQueryValidator()
    {
        RuleFor(x => x.Employee).NotNull();
    }
}
