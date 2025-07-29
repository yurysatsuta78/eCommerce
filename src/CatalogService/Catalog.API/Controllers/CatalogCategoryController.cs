using Catalog.BLL.Dto.Request.CatalogCategory;
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
        public async Task<IActionResult> GetFilteredCategoriesAsync([FromQuery] GetFilteredCategoriesDto dto, 
            CancellationToken cancellationToken)
        {
            var filteredItems = await _catalogCategoryService.GetPaginatedAsync(dto, cancellationToken);

            return Ok(filteredItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCategoryAsync([FromBody] CreateCategoryDto dto, CancellationToken cancellationToken)
        {
            await _catalogCategoryService.AddAsync(dto, cancellationToken);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategoryAsync(Guid id, [FromBody] UpdateCategoryDto dto, CancellationToken cancellationToken)
        {
            await _catalogCategoryService.UpdateAsync(id, dto, cancellationToken);

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
