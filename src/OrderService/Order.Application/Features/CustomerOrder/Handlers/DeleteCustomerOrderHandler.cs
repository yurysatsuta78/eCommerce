using MediatR;
using Order.Application.Features.CustomerOrder.Commands;

namespace Order.Application.Features.CustomerOrder.Handlers
{
    public class DeleteCustomerOrderHandler : IRequestHandler<DeleteCustomerOrderCommand>
    {
        public Task Handle(DeleteCustomerOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
