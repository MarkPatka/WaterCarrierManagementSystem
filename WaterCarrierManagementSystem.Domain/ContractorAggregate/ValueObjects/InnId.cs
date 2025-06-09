using WaterCarrierManagementSystem.Domain.Common.Abstract;

namespace WaterCarrierManagementSystem.Domain.ContractorAggregate.ValueObjects;

public class InnId : ValueObject
{
    public int Value { get; }

    private InnId(int value)
    {
        Value = value;
    }

    public static InnId Create(int number)
    {
        if (IsValid(number.ToString()))
        {
            return new InnId(number);
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
