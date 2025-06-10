using FluentNHibernate.Mapping;
using WaterCarrierManagementSystem.Domain.ContractorAggregate;
using WaterCarrierManagementSystem.Domain.ContractorAggregate.Entities;
using WaterCarrierManagementSystem.Domain.ContractorAggregate.ValueObjects;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings;

public class ContractorMapping 
    : ClassMap<Contractor>, IMapping
{
    public ContractorMapping()
    {
        Table("Contractors");

        Id(x => x.Id)
            .Column("id")
            .CustomType<ContractorId>()
            .GeneratedBy.Identity();

        Map(x => x.Name)
            .Length(100)
            .Not.Nullable();

        Map(x => x.Inn)
            .Column("inn")
            .CustomType<INN>()
            .Not.Nullable();

        References(x => x.Curator)
            .Column("curator_id")
            .Not.Nullable()
            .Cascade.SaveUpdate();
    }
}
