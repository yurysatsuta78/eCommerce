using Catalog.BLL.DTOs.Request.CatalogItem;
using Catalog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class CatalogItemController : ControllerBase
    {
        private readonly ICatalogItemService _catalogItemService;

        public CatalogItemController(ICatalogItemService catalogItemService)
        {
            _catalogItemService = catalogItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredItemsAsync([FromQuery] GetFilteredCatalogItemsRequest filter, 
            CancellationToken cancellationToken) 
        {
            var filteredItems = await _catalogItemService.GetFilteredAsync(filter, cancellationToken);

            return Ok(filteredItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewItemAsync([FromBody] CreateCatalogItemRequest data, CancellationToken cancellationToken) 
        {
            await _catalogItemService.AddAsync(data, cancellationToken);

            return Created();
        }

        [HttpPost("{id:guid}/stock/decrement")]
        public async Task<IActionResult> AddStockAsync(Guid id, [FromBody] RemoveStockRequest data, CancellationToken cancellationToken) 
        {
            var result = await _catalogItemService.RemoveStockAsync(id, data, cancellationToken);

            return Ok(result);
        }

        [HttpPost("{id:guid}/stock/increment")]
        public async Task<IActionResult> AddStockAsync(Guid id, [FromBody] AddStockRequest data, CancellationToken cancellationToken)
        {
            var result = await _catalogItemService.AddStockAsync(id, data, cancellationToken);

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateItemAsync(Guid id, [FromBody] UpdateCatalogItemRequest data, 
            CancellationToken cancellationToken)
        {
            await _catalogItemService.UpdateAsync(id, data, cancellationToken);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartialUpdateItemAsync(Guid id, [FromBody] UpdateCatalogItemRequest data, 
            CancellationToken cancellationToken) 
        {
            await _catalogItemService.UpdateAsync(id, data, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteItemAsync(Guid id, CancellationToken cancellationToken) 
        {
            await _catalogItemService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
