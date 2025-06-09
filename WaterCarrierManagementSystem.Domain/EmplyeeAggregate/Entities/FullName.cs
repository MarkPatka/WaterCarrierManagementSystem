using WaterCarrierManagementSystem.Domain.Common.Abstract;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate.ValueObjects;

namespace WaterCarrierManagementSystem.Domain.EmplyeeAggregate.Entities;

public class FullName : Entity<FullNameId>
{
    public virtual string FirstName   { get; }
    public virtual string LastName    { get; }
    public virtual string? MiddleName { get; }

#pragma warning disable CS8618
    private FullName() { }
#pragma warning restore CS8618

    private FullName(
        FullNameId id, string firstName, string lastName, string? middleName = null)
        : base(id)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be empty", nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name cannot be empty", nameof(lastName));

        FirstName  = firstName.Trim();
        LastName   = lastName.Trim();
        MiddleName = middleName?.Trim();
    }

    public static FullName Create(int id, string firstName, string lastName, string? middleName = null) => 
        new(FullNameId.Create(id), firstName, lastName, middleName);

    public override string ToString() =>
        MiddleName != null
            ? $"{LastName} {FirstName} {MiddleName}"
            : $"{LastName} {FirstName}";
}
