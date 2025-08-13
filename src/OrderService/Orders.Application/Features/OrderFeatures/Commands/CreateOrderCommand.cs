using MediatR;
using Orders.Application.DTOs.Request;
using Orders.Application.DTOs.Response;

namespace Orders.Application.Features.OrderFeatures.Commands
{
    public record CreateOrderCommand : IRequest<OrderResponse>
    {
        public CreateOrderRequest Data { get; init; } = default!;
    }
}
