using WaterCarrierManagementSystem.Domain.Common.Abstract;

namespace WaterCarrierManagementSystem.Domain.OrderAggregate.ValueObjects;

public class OrderId : ValueObject
{
    public Guid Value { get; }

    private OrderId(Guid value) { Value = value; }

    public static OrderId Create(Guid id)
    {
        return new OrderId(id);
    }
    public static OrderId CreateUnic()
    {
        return new OrderId(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
