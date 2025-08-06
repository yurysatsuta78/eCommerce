using MediatR;
using Order.Application.Dto.Request;
using Order.Application.Dto.Response;

namespace Order.Application.Features.CustomerOrder.Commands
{
    public record CreateCustomerOrderCommand : IRequest<CustomerOrderDto>
    {
        public CreateCustomerOrderDto Dto { get; init; }
    }
}
