using MediatR;

namespace Orders.Application.Features.OrderFeatures.Commands
{
    public record DeleteOrderCommand : IRequest 
    {
        public Guid OrderId { get; init; }
    }
}
