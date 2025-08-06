using MediatR;
using Order.Application.Dto.Response;
using Order.Application.Features.CustomerOrder.Queries;

namespace Order.Application.Features.CustomerOrder.Handlers
{
    public class GetCustomerOrderByIdHandler : IRequestHandler<GetCustomerOrderByIdQuery, CustomerOrderDto>
    {
        public Task<CustomerOrderDto> Handle(GetCustomerOrderByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
