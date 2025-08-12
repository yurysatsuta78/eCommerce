using MediatR;

namespace Orders.Application.Features.OrderFeatures.Commands
{
    public record DeleteOrderCommand : IRequest 
    {
        public Guid Id { get; init; }
    }
}
