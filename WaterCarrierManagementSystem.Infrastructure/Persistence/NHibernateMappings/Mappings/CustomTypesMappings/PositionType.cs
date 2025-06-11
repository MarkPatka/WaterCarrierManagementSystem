using WaterCarrierManagementSystem.Domain.EmplyeeAggregate.Enumerations;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings.CustomTypesMappings;

public class PositionType : EnumStringType<Position>
{
    public PositionType() : base(typeof(Position)) { }
}
