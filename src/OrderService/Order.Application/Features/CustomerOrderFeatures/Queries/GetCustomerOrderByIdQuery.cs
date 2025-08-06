using MediatR;
using Order.Application.Dto.Response;

namespace Order.Application.Features.CustomerOrderFeatures.Queries
{
    public record GetCustomerOrderByIdQuery : IRequest<CustomerOrderDto> 
    {
        public Guid CustomerOrderId { get; init; }
    }
}
