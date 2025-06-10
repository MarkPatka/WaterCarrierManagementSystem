namespace WaterCarrierManagementSystem.Desktop.Models;

public record OrderModel(
    Guid Id,
    decimal Amount,
    DateTime DateTime,
    string CuratorName,
    string ContractorName);
