using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Dto.Request;
using Order.Application.Features.CustomerOrderFeatures.Commands;
using Order.Application.Features.CustomerOrderFeatures.Queries;

namespace Order.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredOrdersAsync([FromQuery] GetFilteredCustomerOrdersDto dto,
            CancellationToken cancellationToken)
        {
            var query = new GetFilteredCustomerOrdersQuery { Filter = dto };
            var orders = await _mediator.Send(query, cancellationToken);

            return Ok(orders);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken) 
        {
            var query = new GetCustomerOrderByIdQuery { CustomerOrderId = orderId };
            var order = await _mediator.Send(query, cancellationToken);

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync([FromBody] CreateCustomerOrderDto dto, CancellationToken cancellationToken) 
        {
            var command = new CreateCustomerOrderCommand { Dto = dto };
            var newOrder = await _mediator.Send(command, cancellationToken);

            return Ok(newOrder);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteOrderAsync(Guid orderId, CancellationToken cancellationToken) 
        {
            var command = new DeleteCustomerOrderCommand { CustomerOrderId = orderId };
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
