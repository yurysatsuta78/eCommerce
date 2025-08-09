using MediatR;
using Orders.Application.DTOs.Response;

namespace Orders.Application.Features.OrderFeatures.Queries
{
    public record GetOrderByIdQuery : IRequest<OrderResponse> 
    {
        public Guid OrderId { get; init; }
    }
}
