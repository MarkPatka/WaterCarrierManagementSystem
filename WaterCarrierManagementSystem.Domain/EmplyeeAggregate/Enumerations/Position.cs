using WaterCarrierManagementSystem.Domain.Common.Abstract;

namespace WaterCarrierManagementSystem.Domain.EmplyeeAggregate.Enumerations;
public sealed class Position(int id, string name, string? description = null)
    : Enumeration(id, name, description)
{
    public static readonly Position MANAGER  = new(1, nameof(MANAGER),  "Руководитель");
    public static readonly Position EMPLOYEE = new(2, nameof(EMPLOYEE), "Работник");
}

