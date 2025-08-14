using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.DTOs.BasketDTOs;
using Orders.Application.DTOs.OrderDTOs;
using Orders.Application.Features.OrderFeatures.Commands;
using Orders.Application.Features.OrderFeatures.Queries;

namespace Orders.API.Controllers
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
        public async Task<IActionResult> GetFilteredOrdersAsync([FromQuery] GetFilteredOrdersDTO dto,
            CancellationToken cancellationToken)
        {
            var query = new GetFilteredOrdersQuery { Dto = dto };
            var orders = await _mediator.Send(query, cancellationToken);

            return Ok(orders);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken) 
        {
            var query = new GetOrderByIdQuery { Id = id };
            var order = await _mediator.Send(query, cancellationToken);

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync([FromBody] BasketDTO basket, CancellationToken cancellationToken) 
        {
            var command = new CreateOrderCommand { Basket = basket };
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteOrderAsync(Guid id, CancellationToken cancellationToken) 
        {
            var command = new DeleteOrderCommand { Id = id };
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
