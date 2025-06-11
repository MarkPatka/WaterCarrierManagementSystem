using FluentNHibernate.Mapping;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate.Enumerations;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate.ValueObjects;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate;
using WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings.CustomTypesMappings;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings;

public class EmployeeMapping 
    : ClassMap<Employee>, IMapping
{
    public EmployeeMapping()
    {
        Table("Employees");

        Id(x => x.Id)
            .Column("Id")
            .CustomType<EmployeeIdType>()
            .GeneratedBy.Assigned();

        Component(x => x.Name, m =>
        {
            m.Map(x => x.FirstName, "FirstName").Length(100);
            m.Map(x => x.LastName, "LastName").Length(100);
            m.Map(x => x.MiddleName, "MiddleName").Length(100).Nullable();
        });

        Map(x => x.Position)
            .CustomType<PositionType>()
            .Not.Nullable();

        Map(x => x.BirthDate)
            .CustomType<DateOnlyType>()
            .Not.Nullable();
    }
}
