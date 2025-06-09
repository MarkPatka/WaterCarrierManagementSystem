using WaterCarrierManagementSystem.Domain.Common.Abstract;

namespace WaterCarrierManagementSystem.Domain.EmplyeeAggregate.ValueObjects;

public class EmployeeId : ValueObject
{
    public int Value { get; }

    private EmployeeId(int value)
    {
        Value = value;
    }

    public static EmployeeId Create(int id)
    {
        return new EmployeeId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
