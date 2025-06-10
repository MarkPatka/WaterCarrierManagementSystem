using NHibernate;
using WaterCarrierManagementSystem.Application.Common.Persistence;
using WaterCarrierManagementSystem.Application.Common.Persistence.Repositories;
using WaterCarrierManagementSystem.Domain.OrderAggregate;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.Repositories;

public class OrderRepository 
    : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(ISession session) : base(session)
    {
    }
}
