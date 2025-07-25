using Catalog.BLL.Dto.Request.CatalogBrand;
using Catalog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogBrandController : ControllerBase
    {
        private readonly ICatalogBrandService _catalogBrandService;

        public CatalogBrandController(ICatalogBrandService catalogBrandService)
        {
            _catalogBrandService = catalogBrandService;
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetFilteredBrandsAsync([FromQuery] GetFilteredBrandsDto dto, CancellationToken cancellationToken)
        {
            var filteredItems = await _catalogBrandService.GetPaginatedAsync(dto, cancellationToken);

            return Ok(filteredItems);
        }

        [HttpPost("brands")]
        public async Task<IActionResult> AddNewBrandAsync([FromBody] CreateBrandDto dto, CancellationToken cancellationToken)
        {
            await _catalogBrandService.AddAsync(dto, cancellationToken);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPatch("brands/{id}")]
        public async Task<IActionResult> UpdateBrandAsync(Guid id, [FromBody] UpdateBrandDto dto, CancellationToken cancellationToken)
        {
            await _catalogBrandService.UpdateAsync(id, dto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("brands/{id}")]
        public async Task<IActionResult> DeleteBrandAsync(Guid id, CancellationToken cancellationToken)
        {
            await _catalogBrandService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
