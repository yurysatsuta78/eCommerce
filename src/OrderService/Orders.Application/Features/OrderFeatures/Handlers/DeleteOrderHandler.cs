using AutoMapper;
using MediatR;
using Orders.Application.Features.OrderFeatures.Commands;
using Orders.Domain.Exceptions;
using Orders.Domain.Interfaces;

namespace Orders.Application.Features.OrderFeatures.Handlers
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrdersRepository _ordersRepository;

        public DeleteOrderHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetByIdAsync(request.OrderId, false, cancellationToken)
                ?? throw new OrderNotFoundException($"Order with id: {request.OrderId} not found.");

            _ordersRepository.Delete(order);
            await _ordersRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
