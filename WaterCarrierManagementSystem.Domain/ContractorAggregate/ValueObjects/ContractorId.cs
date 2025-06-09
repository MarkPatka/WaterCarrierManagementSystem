using WaterCarrierManagementSystem.Domain.Common.Abstract;

namespace WaterCarrierManagementSystem.Domain.ContractorAggregate.ValueObjects;

public class ContractorId : ValueObject
{
    public int Value { get; }

    private ContractorId(int value)
    {
        Value = value;
    }

    public static ContractorId Create(int value)
    {
        return new ContractorId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
