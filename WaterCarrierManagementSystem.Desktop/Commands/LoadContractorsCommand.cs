using WaterCarrierManagementSystem.Application.Common.Persistence;
using WaterCarrierManagementSystem.Application.Common.Persistence.Repositories;
using WaterCarrierManagementSystem.Desktop.Commands.Abstract;
using WaterCarrierManagementSystem.Domain.ContractorAggregate;

namespace WaterCarrierManagementSystem.Desktop.Commands;

public class LoadContractorsCommand(IContractorRepository contractorRepository)
    : AsyncRelayCommand<LoadContractorsResult>
{
    private readonly IContractorRepository _contractorsRepositoryUnit = contractorRepository;

    public override Func<object?, Task<CommandResult<LoadContractorsResult>>> ExecuteCommand => LoadAllContractors;

    public override Predicate<object?>? CanExecuteCommand => null;

    public override Action<Exception>? ErrorHandler => LogError;

    private async Task<CommandResult<LoadContractorsResult>> LoadAllContractors(object? parameter = null)
    {
        try
        {
            var data = _contractorsRepositoryUnit.GetAll();
            LoadContractorsResult result = new(data);

            return new CommandResult<LoadContractorsResult>(result);
        }
        catch (Exception ex)
        {
            ErrorHandler?.Invoke(ex);
            return new CommandResult<LoadContractorsResult>(ex);
        }
    }

    private void LogError(Exception message)
    {
        Console.WriteLine(message.Message);
    }
}

public record LoadContractorsResult(IList<Contractor> Contractors);
