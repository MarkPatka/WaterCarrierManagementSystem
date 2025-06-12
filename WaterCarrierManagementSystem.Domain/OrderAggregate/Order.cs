using WaterCarrierManagementSystem.Domain.Common.Abstract;
using WaterCarrierManagementSystem.Domain.ContractorAggregate;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate;
using WaterCarrierManagementSystem.Domain.OrderAggregate.ValueObjects;

namespace WaterCarrierManagementSystem.Domain.OrderAggregate;

public class Order : AggregateRoot<OrderId>
{
    public virtual DateTime OrderDateTime  { get; }
    public virtual decimal Amount          { get; }
    public virtual Employee Employee       { get; } = null!;
    public virtual Contractor Contractor   { get; } = null!;

    protected Order() { } 

    private Order(OrderId id, 
        DateTime orderDate, decimal amount, Employee employee, Contractor contractor) 
        : base(id)
    {
        if (amount < 0)
            throw new ArgumentException("Amount must be positive", nameof(amount));

        OrderDateTime = orderDate;
        Amount = amount;
        Employee = employee ?? throw new ArgumentNullException(nameof(employee));
        Contractor = contractor ?? throw new ArgumentNullException(nameof(contractor));
    }

    public static Order Create(DateTime orderDate, decimal amount, Employee employee, Contractor counterparty) =>
        new(OrderId.Create(Guid.NewGuid()), orderDate, amount, employee, counterparty);


    public override bool Equals(object obj) => base.Equals(obj);
    public override int GetHashCode() => base.GetHashCode();
}
