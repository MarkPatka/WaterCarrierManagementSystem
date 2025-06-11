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
            .Column("id")
            .CustomType<EmployeeIdType>();

        Map(x => x.Name)
        .CustomType<FullNameType>()  
            .Columns.Add("first_name")   
            .Columns.Add("last_name")
            .Columns.Add("middle_name");

        //Component(x => x.Name, m =>
        //{
        //    m.Map(x => x.FirstName, "name").Length(100);
        //    m.Map(x => x.LastName, "last_name").Length(100);
        //    m.Map(x => x.MiddleName, "middle_name").Length(100).Nullable();
        //});

        Map(x => x.Position)
            .Column("position")
            .CustomType<PositionType>()
            .Not.Nullable();

        Map(x => x.BirthDate)
            .Column("birth_date")
            .CustomType<DateOnlyType>()
            .Not.Nullable();
    }
}
