using Catalog.BLL.Dto.Request.CatalogItem;
using Catalog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogItemController : ControllerBase
    {
        private readonly ICatalogItemService _catalogItemService;

        public CatalogItemController(ICatalogItemService catalogItemService)
        {
            _catalogItemService = catalogItemService;
        }

        [HttpGet("items")]
        public async Task<IActionResult> GetFilteredItemsAsync([FromQuery] GetFilteredCatalogItemsDto dto, CancellationToken cancellationToken) 
        {
            var filteredItems = await _catalogItemService.GetPaginatedAsync(dto, cancellationToken);

            return Ok(filteredItems);
        }

        [HttpPost("items")]
        public async Task<IActionResult> AddNewItemAsync([FromBody] CreateCatalogItemDto dto, CancellationToken cancellationToken) 
        {
            await _catalogItemService.AddAsync(dto, cancellationToken);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("items/{id}/stock/decrement")]
        public async Task<IActionResult> AddStockAsync(Guid id, [FromBody] RemoveStockDto dto, CancellationToken cancellationToken) 
        {
            var result = await _catalogItemService.RemoveStockAsync(id, dto, cancellationToken);

            return Ok(result);
        }

        [HttpPost("items/{id}/stock/increment")]
        public async Task<IActionResult> AddStockAsync(Guid id, [FromBody] AddStockDto dto, CancellationToken cancellationToken)
        {
            var result = await _catalogItemService.AddStockAsync(id, dto, cancellationToken);

            return Ok(result);
        }

        [HttpPatch("items/{id}")]
        public async Task<IActionResult> UpdateItemAsync(Guid id, [FromBody] UpdateCatalogItemDto dto, CancellationToken cancellationToken) 
        {
            await _catalogItemService.UpdateAsync(id, dto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("items/{id}")]
        public async Task<IActionResult> DeleteItemAsync(Guid id, CancellationToken cancellationToken) 
        {
            await _catalogItemService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
