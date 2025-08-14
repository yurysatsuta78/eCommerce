using MediatR;
using Orders.Application.DTOs.OrderDTOs;

namespace Orders.Application.Features.OrderFeatures.Queries
{
    public record GetOrderByIdQuery : IRequest<OrderDTO> 
    {
        public Guid Id { get; init; }
    }
}
