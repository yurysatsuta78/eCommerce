using MediatR;
using Orders.Application.DTOs.Order;

namespace Orders.Application.Features.OrderFeatures.Queries
{
    public record GetOrderByIdQuery : IRequest<OrderDTO> 
    {
        public Guid Id { get; init; }
    }
}
