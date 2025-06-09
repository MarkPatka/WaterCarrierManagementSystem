using MediatR;

namespace WaterCarrierManagementSystem.Application.Common.Interfaces;

public interface IQuery<out TResponse> 
    : IRequest<TResponse>
{
}
