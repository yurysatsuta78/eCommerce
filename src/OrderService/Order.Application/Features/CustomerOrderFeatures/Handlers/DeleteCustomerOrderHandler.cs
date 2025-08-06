using AutoMapper;
using MediatR;
using Order.Application.Features.CustomerOrderFeatures.Commands;
using Order.Domain.Exceptions;
using Order.Domain.Interfaces;

namespace Order.Application.Features.CustomerOrderFeatures.Handlers
{
    public class DeleteCustomerOrderHandler : IRequestHandler<DeleteCustomerOrderCommand>
    {
        private readonly ICustomerOrdersRepository _customerOrdersRepository;

        public DeleteCustomerOrderHandler(ICustomerOrdersRepository customerOrdersRepository)
        {
            _customerOrdersRepository = customerOrdersRepository;
        }

        public async Task Handle(DeleteCustomerOrderCommand request, CancellationToken cancellationToken)
        {
            var customerOrder = await _customerOrdersRepository.GetByIdAsync(request.CustomerOrderId, false, cancellationToken)
                ?? throw new OrderNotFoundException($"Order with id: {request.CustomerOrderId} not found.");

            _customerOrdersRepository.Delete(customerOrder);
            await _customerOrdersRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
