using WaterCarrierManagementSystem.Domain.Common.Abstract;
using WaterCarrierManagementSystem.Domain.ContractorAggregate.ValueObjects;

namespace WaterCarrierManagementSystem.Domain.ContractorAggregate.Entities;

public class INN : Entity<InnId>
{
    public Int64 Number { get; }

    private INN() { }

    private INN(InnId inn, Int64 number) : base(inn) { Number = number; }
    public static INN Create(int innId, long innNumber) =>
        new(InnId.Create(innId), innNumber);
}
