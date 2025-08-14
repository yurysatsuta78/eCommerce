using Catalog.BLL.DTOs.CategoryDTOs;
using Catalog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService) 
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredCategoriesAsync([FromQuery] GetFilteredCategoriesDTO dto, 
            CancellationToken cancellationToken)
        {
            var filteredCategories = await _categoriesService.GetFilteredAsync(dto, cancellationToken);

            return Ok(filteredCategories);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCategoryAsync([FromBody] CreateCategoryDTO dto, 
            CancellationToken cancellationToken)
        {
            await _categoriesService.AddAsync(dto, cancellationToken);

            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategoryAsync(Guid id, [FromBody] UpdateCategoryDTO dto, 
            CancellationToken cancellationToken)
        {
            await _categoriesService.UpdateAsync(id, dto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategoryAsync(Guid id, CancellationToken cancellationToken)
        {
            await _categoriesService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
