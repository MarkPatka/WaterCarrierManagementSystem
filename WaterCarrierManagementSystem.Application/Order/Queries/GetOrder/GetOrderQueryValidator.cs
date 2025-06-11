using FluentValidation;

namespace WaterCarrierManagementSystem.Application.Order.Queries.GetOrder;

public class GetOrderQueryValidator
    : AbstractValidator<GetOrderQuery>
{
    public GetOrderQueryValidator()
    {
        RuleFor(x => x.ContractorName).NotEmpty();
    }
}
