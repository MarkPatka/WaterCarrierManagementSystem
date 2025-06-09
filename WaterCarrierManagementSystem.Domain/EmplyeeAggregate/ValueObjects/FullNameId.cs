using WaterCarrierManagementSystem.Domain.Common.Abstract;

namespace WaterCarrierManagementSystem.Domain.EmplyeeAggregate.ValueObjects;

public class FullNameId : ValueObject
{
    public int Value { get; }

    private FullNameId(int value)
    {
        Value = value;
    }

    public static FullNameId Create(int id)
    {
        return new FullNameId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
