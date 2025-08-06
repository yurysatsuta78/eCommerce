using MediatR;
using Order.Application.Features.CustomerOrderFeatures.Commands;

namespace Order.Application.Features.CustomerOrderFeatures.Handlers
{
    public class DeleteCustomerOrderHandler : IRequestHandler<DeleteCustomerOrderCommand>
    {
        public Task Handle(DeleteCustomerOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
