using WaterCarrierManagementSystem.Domain.Common.Abstract;
using WaterCarrierManagementSystem.Domain.ContractorAggregate.ValueObjects;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate;

namespace WaterCarrierManagementSystem.Domain.ContractorAggregate;

public class Contractor : AggregateRoot<ContractorId>
{
    public virtual string Name      { get; } = null!;
    public virtual INN Inn          { get; } = null!;
    public virtual Employee Curator { get; } = null!;

    protected Contractor() { } 

    private Contractor(ContractorId id, 
        string name, Int64 inn, Employee curator) 
        : base(id)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));

        Name = name.Trim();
        Inn = INN.Create(inn) ?? throw new ArgumentNullException(nameof(inn));
        Curator = curator ?? throw new ArgumentNullException(nameof(curator));
    }

    public static Contractor Create(int id, string name, Int64 inn, Employee employee) =>
        new(ContractorId.Create(id), name, inn, employee);

    public override bool Equals(object obj) => base.Equals(obj);
    public override int GetHashCode() => base.GetHashCode();
}
