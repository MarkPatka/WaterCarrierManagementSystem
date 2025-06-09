using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using WaterCarrierManagementSystem.Domain.Common.Abstract;
using WaterCarrierManagementSystem.Domain.ContractorAggregate;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate;
using WaterCarrierManagementSystem.Domain.OrderAggregate.ValueObjects;

namespace WaterCarrierManagementSystem.Domain.OrderAggregate;

public class Order : AggregateRoot<OrderId>
{
    public virtual DateTime OrderDateTime  { get; }
    public virtual decimal Amount          { get; }
    public virtual Employee Employee       { get; }
    public virtual Contractor Counterparty { get; }

    private Order() { } 

    private Order(OrderId id, 
        DateTime orderDate, decimal amount, Employee employee, Contractor counterparty) 
        : base(id)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive", nameof(amount));

        OrderDateTime = orderDate;
        Amount = amount;
        Employee = employee ?? throw new ArgumentNullException(nameof(employee));
        Counterparty = counterparty ?? throw new ArgumentNullException(nameof(counterparty));
    }

    public static Order Create(DateTime orderDate, decimal amount, Employee employee, Contractor counterparty) =>
        new(OrderId.Create(Guid.NewGuid()), orderDate, amount, employee, counterparty);
}
