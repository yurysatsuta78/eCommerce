using Basket.BLL.Dto;
using Basket.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/baskets")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService) 
        {
            _basketService = basketService;
        }


        [HttpGet("{customerId:guid}")]
        public async Task<IActionResult> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken) 
        {
            var basket = await _basketService.GetByCustomerIdAsync(customerId, cancellationToken);

            return Ok(basket);
        }


        [HttpPut("{customerId:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid customerId, [FromBody] CustomerBasketDto dto, CancellationToken cancellationToken) 
        {
            await _basketService.UpdateAsync(customerId, dto, cancellationToken);

            return Ok();
        }


        [HttpDelete("{customerId:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid customerId, CancellationToken cancellationToken) 
        {
            await _basketService.DeleteAsync(customerId, cancellationToken);

            return NoContent();
        }
    }
}
