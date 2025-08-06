using MediatR;
using Orders.Application.Dto.Response;

namespace Orders.Application.Features.OrderFeatures.Queries
{
    public record GetOrderByIdQuery : IRequest<OrderDto> 
    {
        public Guid OrderId { get; init; }
    }
}
