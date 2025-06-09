using WaterCarrierManagementSystem.Domain.Common.Abstract;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate.Entities;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate.Enumerations;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate.ValueObjects;

namespace WaterCarrierManagementSystem.Domain.EmplyeeAggregate;

public class Employee : AggregateRoot<EmployeeId>
{
    public virtual FullName Name      { get; }
    public virtual Position Position  { get; }
    public virtual DateOnly BirthDate { get; }

#pragma warning disable CS8618
    private Employee() { }
#pragma warning restore CS8618
    
    private Employee(EmployeeId id, 
        FullName name, Position position, DateOnly birthDate) 
        : base(id)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Position = position;
        BirthDate = birthDate;
    }

    public static Employee Create(int id, FullName name, Position position, DateOnly birthDate) =>
        new(EmployeeId.Create(id), name, position, birthDate);
}
