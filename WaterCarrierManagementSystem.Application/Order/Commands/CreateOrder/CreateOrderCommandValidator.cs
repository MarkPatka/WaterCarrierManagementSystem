using FluentValidation;

namespace WaterCarrierManagementSystem.Application.Order.Commands.CreateOrder;

public class CreateOrderCommandValidator
    : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.NewOrder).NotNull();
    }
}
