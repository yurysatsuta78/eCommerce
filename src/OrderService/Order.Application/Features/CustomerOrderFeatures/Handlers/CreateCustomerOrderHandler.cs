using MediatR;
using Order.Application.Dto.Response;
using Order.Application.Features.CustomerOrderFeatures.Commands;

namespace Order.Application.Features.CustomerOrderFeatures.Handlers
{
    public class CreateCustomerOrderHandler : IRequestHandler<CreateCustomerOrderCommand, CustomerOrderDto>
    {
        public Task<CustomerOrderDto> Handle(CreateCustomerOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
