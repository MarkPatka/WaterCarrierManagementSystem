using MediatR;

namespace WaterCarrierManagementSystem.Application.Common.Interfaces;

public interface ICommand<out TResponse> 
    : IRequest<TResponse>
{
}
