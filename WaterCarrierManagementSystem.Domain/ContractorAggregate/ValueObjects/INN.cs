using WaterCarrierManagementSystem.Domain.Common.Abstract;

namespace WaterCarrierManagementSystem.Domain.ContractorAggregate.ValueObjects;

public class INN : ValueObject
{
    public Int64 Value { get; }

    private INN(Int64 value)
    {
        Value = value;
    }

    public static INN Create(Int64 number)
    {
        if (IsValid(number.ToString()))
        {
            return new INN(number);
        }
        else throw new ArgumentException(
            "Invalid INN format.", nameof(number));
    }

    private static bool IsValid(string inn)
    {
        return inn.Length == 10 || inn.Length == 12;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();

}
