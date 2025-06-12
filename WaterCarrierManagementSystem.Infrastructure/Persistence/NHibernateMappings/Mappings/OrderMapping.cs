using FluentNHibernate.Mapping;
using WaterCarrierManagementSystem.Domain.OrderAggregate;
using WaterCarrierManagementSystem.Domain.OrderAggregate.ValueObjects;
using WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings.CustomTypesMappings;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings;

public class OrderMapping 
    : ClassMap<Order>, IMapping
{
    public OrderMapping()
    {
        Table("Orders");

        Id(x => x.Id)
            .Column("id")
            .CustomType<OrderIdType>();

        Map(x => x.OrderDateTime)
            .Column("order_date")
            .Not.Nullable();

        Map(x => x.Amount)
            .Precision(2)
            .Not.Nullable();

        References(x => x.Employee)
            .Column("employee_id")
            .Not.Nullable()
            .Cascade.SaveUpdate();

        References(x => x.Contractor)
            .Column("contractor_id")
            .Not.Nullable()
            .Cascade.SaveUpdate();
    }
}