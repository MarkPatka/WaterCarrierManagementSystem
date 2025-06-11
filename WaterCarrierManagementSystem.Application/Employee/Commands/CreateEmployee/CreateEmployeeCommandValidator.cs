using FluentValidation;

namespace WaterCarrierManagementSystem.Application.Employee.Commands.CreateEmployee;

public class CreateEmployeeCommandValidator
    : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.Employee).NotNull();
    }
}
