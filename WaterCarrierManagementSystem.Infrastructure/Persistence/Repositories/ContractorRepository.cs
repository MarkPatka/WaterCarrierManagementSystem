using NHibernate;
using WaterCarrierManagementSystem.Application.Common.Persistence;
using WaterCarrierManagementSystem.Application.Common.Persistence.Repositories;
using WaterCarrierManagementSystem.Domain.ContractorAggregate;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.Repositories;

public class ContractorRepository
    : GenericRepository<Contractor>, IContractorRepository
{
    public ContractorRepository(ISession session) : base(session)
    {

    }
}
