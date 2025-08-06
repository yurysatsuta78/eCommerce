using MediatR;
using Order.Application.Dto.Response;
using Order.Application.Features.CustomerOrderFeatures.Queries;

namespace Order.Application.Features.CustomerOrderFeatures.Handlers
{
    public class GetCustomerOrderByIdHandler : IRequestHandler<GetCustomerOrderByIdQuery, CustomerOrderDto>
    {
        public Task<CustomerOrderDto> Handle(GetCustomerOrderByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
