using MediatR;
using Orders.Application.DTOs.BasketDTOs;

namespace Orders.Application.Features.OrderFeatures.Commands
{
    public record CreateOrderCommand : IRequest
    {
        public BasketDTO Basket { get; init; } = default!;
    }
}
