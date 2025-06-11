using FluentValidation;

namespace WaterCarrierManagementSystem.Application.Order.Queries.UpdateOrder;

public class UpdateOrderQueryValidator
    : AbstractValidator<UpdateOrderQuery>
{
    public UpdateOrderQueryValidator()
    {
        RuleFor(x => x.UpdatedOrder).NotEmpty();
    }
}
