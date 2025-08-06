using AutoMapper;
using MediatR;
using Order.Application.Dto.Response;
using Order.Application.Features.CustomerOrderFeatures.Commands;
using Order.Domain.Interfaces;
using Order.Domain.Models;

namespace Order.Application.Features.CustomerOrderFeatures.Handlers
{
    public class CreateCustomerOrderHandler : IRequestHandler<CreateCustomerOrderCommand, CustomerOrderDto>
    {
        private readonly ICustomerOrdersRepository _customerOrdersRepository;
        private readonly IMapper _mapper;

        public CreateCustomerOrderHandler(ICustomerOrdersRepository customerOrdersRepository, IMapper mapper) 
        {
            _customerOrdersRepository = customerOrdersRepository;
            _mapper = mapper;
        }

        public async Task<CustomerOrderDto> Handle(CreateCustomerOrderCommand request, CancellationToken cancellationToken)
        {
            var customerOrder = _mapper.Map<CustomerOrder>(request.Dto);

            await _customerOrdersRepository.AddAsync(customerOrder, cancellationToken);
            await _customerOrdersRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CustomerOrderDto>(customerOrder);
        }
    }
}
