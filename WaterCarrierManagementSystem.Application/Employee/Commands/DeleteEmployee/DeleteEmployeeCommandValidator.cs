using FluentValidation;

namespace WaterCarrierManagementSystem.Application.Employee.Commands.DeleteEmployee;

public class DeleteEmployeeCommandValidator
    : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
