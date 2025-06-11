using WaterCarrierManagementSystem.Domain.EmplyeeAggregate.Enumerations;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings.CustomTypesMappings;

public class PositionType : EnumIntType<Position>
{
    public PositionType() : base(typeof(Position)) { }
}
