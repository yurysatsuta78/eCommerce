using Catalog.BLL.DTOs.Request.CatalogCategory;
using Catalog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CatalogCategoryController : ControllerBase
    {
        private readonly ICatalogCategoryService _catalogCategoryService;

        public CatalogCategoryController(ICatalogCategoryService catalogCategoryService) 
        {
            _catalogCategoryService = catalogCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredCategoriesAsync([FromQuery] GetFilteredCategoriesRequest filter, 
            CancellationToken cancellationToken)
        {
            var filteredItems = await _catalogCategoryService.GetFilteredAsync(filter, cancellationToken);

            return Ok(filteredItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCategoryAsync([FromBody] CreateCategoryRequest data, CancellationToken cancellationToken)
        {
            await _catalogCategoryService.AddAsync(data, cancellationToken);

            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategoryAsync(Guid id, [FromBody] UpdateCategoryRequest data, 
            CancellationToken cancellationToken)
        {
            await _catalogCategoryService.UpdateAsync(id, data, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategoryAsync(Guid id, CancellationToken cancellationToken)
        {
            await _catalogCategoryService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
