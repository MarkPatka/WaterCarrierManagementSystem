using NHibernate;
using WaterCarrierManagementSystem.Application.Common.Persistence;
using WaterCarrierManagementSystem.Application.Common.Persistence.Repositories;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.Repositories;

public class EmployeeRepository
    : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ISession session) : base(session)
    {

    }
}
