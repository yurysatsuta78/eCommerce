using MediatR;
using Orders.Application.Dto.Request;
using Orders.Application.Dto.Response;

namespace Orders.Application.Features.OrderFeatures.Commands
{
    public record CreateOrderCommand : IRequest<OrderDto>
    {
        public CreateOrderDto Dto { get; init; } = default!;
    }
}
