using MediatR;

namespace Order.Application.Features.CustomerOrderFeatures.Commands
{
    public record DeleteCustomerOrderCommand : IRequest 
    {
        public Guid CustomerOrderId { get; init; }
    }
}
