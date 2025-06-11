using FluentNHibernate.Mapping;
using WaterCarrierManagementSystem.Domain.ContractorAggregate;
using WaterCarrierManagementSystem.Domain.ContractorAggregate.ValueObjects;
using WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings.CustomTypesMappings;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings;

public class ContractorMapping 
    : ClassMap<Contractor>, IMapping
{
    public ContractorMapping()
    {
        Table("Contractors");

        Id(x => x.Id)
            .Column("id")
            .CustomType<ContractorIdType>();

        Map(x => x.Name)
            .Length(100)
            .Not.Nullable();

        Map(x => x.Inn)
            .Column("inn")
            .CustomType<InnType>()
            .Not.Nullable();

        References(x => x.Curator)
            .Column("curator_id")
            .Not.Nullable()
            .Cascade.SaveUpdate();
    }
}
