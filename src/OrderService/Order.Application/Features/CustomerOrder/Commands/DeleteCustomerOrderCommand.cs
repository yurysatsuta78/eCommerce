using MediatR;

namespace Order.Application.Features.CustomerOrder.Commands
{
    public record DeleteCustomerOrderCommand : IRequest 
    {
        public Guid CustomerOrderId { get; init; }
    }
}
