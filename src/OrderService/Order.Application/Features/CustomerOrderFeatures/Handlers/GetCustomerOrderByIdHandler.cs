using AutoMapper;
using MediatR;
using Order.Application.Dto.Response;
using Order.Application.Features.CustomerOrderFeatures.Queries;
using Order.Domain.Exceptions;
using Order.Domain.Interfaces;

namespace Order.Application.Features.CustomerOrderFeatures.Handlers
{
    public class GetCustomerOrderByIdHandler : IRequestHandler<GetCustomerOrderByIdQuery, CustomerOrderDto>
    {
        private readonly ICustomerOrdersRepository _customerOrdersRepository;
        private readonly IMapper _mapper;

        public GetCustomerOrderByIdHandler(ICustomerOrdersRepository customerOrdersRepository, IMapper mapper)
        {
            _customerOrdersRepository = customerOrdersRepository;
            _mapper = mapper;
        }

        public async Task<CustomerOrderDto> Handle(GetCustomerOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var customerOrder = await _customerOrdersRepository.GetByIdAsync(request.CustomerOrderId, true, cancellationToken)
                ?? throw new OrderNotFoundException($"Order with id: {request.CustomerOrderId} not found.");

            var customerOrderDto = _mapper.Map<CustomerOrderDto>(customerOrder);

            return customerOrderDto;
        }
    }
}
