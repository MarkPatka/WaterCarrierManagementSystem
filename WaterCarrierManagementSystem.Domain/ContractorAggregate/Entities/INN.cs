using WaterCarrierManagementSystem.Domain.Common.Abstract;
using WaterCarrierManagementSystem.Domain.ContractorAggregate.ValueObjects;

namespace WaterCarrierManagementSystem.Domain.ContractorAggregate.Entities;

public class INN : Entity<InnId>
{
    private INN() { }
    private INN(InnId inn) : base(inn) { }
    public static INN Create(int innNumber) =>
        new(InnId.Create(innNumber));
}
