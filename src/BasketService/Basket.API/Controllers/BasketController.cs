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
        public async Task<IActionResult> GetByCustomerIdAsync(Guid customerId) 
        {
            return Ok(await _basketService.GetByCustomerIdAsync(customerId));
        }

        [HttpPut("{customerId:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid customerId, [FromBody] CustomerBasketDto dto) 
        {
            return Ok(await _basketService.UpdateAsync(customerId, dto));
        }

        [HttpDelete("{customerId:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid customerId) 
        {
            await _basketService.DeleteAsync(customerId);

            return NoContent();
        }
    }
}
