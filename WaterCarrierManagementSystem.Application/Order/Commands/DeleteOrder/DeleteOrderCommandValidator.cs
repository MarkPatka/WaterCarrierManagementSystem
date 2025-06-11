using FluentValidation;

namespace WaterCarrierManagementSystem.Application.Order.Commands.DeleteOrder;

public class DeleteOrderCommandValidator
    : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }

}
