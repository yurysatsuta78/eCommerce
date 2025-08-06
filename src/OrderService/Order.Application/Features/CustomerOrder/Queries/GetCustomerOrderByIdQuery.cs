using MediatR;
using Order.Application.Dto.Response;

namespace Order.Application.Features.CustomerOrder.Queries
{
    public record GetCustomerOrderByIdQuery : IRequest<CustomerOrderDto> 
    {
        public Guid CustomerOrderId { get; init; }
    }
}
