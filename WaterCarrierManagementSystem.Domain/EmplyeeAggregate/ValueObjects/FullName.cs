using WaterCarrierManagementSystem.Domain.Common.Abstract;

namespace WaterCarrierManagementSystem.Domain.EmplyeeAggregate.ValueObjects;

public class FullName : ValueObject
{
    public virtual string FirstName   { get; protected set; } 
    public virtual string LastName    { get; protected set; }
    public virtual string? MiddleName { get; protected set; }


    private FullName(
        string firstName, string lastName, string? middleName = null)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be empty", nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name cannot be empty", nameof(lastName));

        FirstName  = firstName.Trim();
        LastName   = lastName.Trim();
        MiddleName = middleName?.Trim();
    }

    public static FullName Create(string firstName, string lastName, string? middleName = null) => 
        new(firstName, lastName, middleName);

    public override string ToString() =>
        MiddleName != null
            ? $"{LastName} {FirstName} {MiddleName}"
            : $"{LastName} {FirstName}";

    public override IEnumerable<object> GetEqualityComponents()
    {

        yield return FirstName;
        yield return LastName;
        yield return MiddleName ?? "";
    }
}
