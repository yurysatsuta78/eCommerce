using Catalog.BLL.DTOs.ProductDTOs;
using Catalog.BLL.DTOs.ProductDTOs.Stock;
using Catalog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredItemsAsync([FromQuery] GetFilteredProductsDTO dto, 
            CancellationToken cancellationToken) 
        {
            var filteredProducts = await _productsService.GetFilteredAsync(dto, cancellationToken);

            return Ok(filteredProducts);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewItemAsync([FromBody] CreateProductDTO dto, 
            CancellationToken cancellationToken) 
        {
            await _productsService.AddAsync(dto, cancellationToken);

            return Created();
        }

        [HttpPost("{id:guid}/stock/remove")]
        public async Task<IActionResult> AddStockAsync(Guid id, [FromBody] RemoveStockDTO dto, 
            CancellationToken cancellationToken) 
        {
            await _productsService.RemoveStockAsync(id, dto, cancellationToken);

            return NoContent();
        }

        [HttpPost("{id:guid}/stock/add")]
        public async Task<IActionResult> AddStockAsync(Guid id, [FromBody] AddStockDTO dto, 
            CancellationToken cancellationToken)
        {
            await _productsService.AddStockAsync(id, dto, cancellationToken);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateItemAsync(Guid id, [FromBody] UpdateProductDTO dto, 
            CancellationToken cancellationToken)
        {
            await _productsService.UpdateAsync(id, dto, cancellationToken);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartialUpdateItemAsync(Guid id, [FromBody] UpdateProductDTO dto, 
            CancellationToken cancellationToken) 
        {
            await _productsService.UpdateAsync(id, dto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteItemAsync(Guid id, CancellationToken cancellationToken) 
        {
            await _productsService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
