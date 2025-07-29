using Catalog.BLL.Dto.Request.CatalogBrand;
using Catalog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class CatalogBrandController : ControllerBase
    {
        private readonly ICatalogBrandService _catalogBrandService;

        public CatalogBrandController(ICatalogBrandService catalogBrandService)
        {
            _catalogBrandService = catalogBrandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredBrandsAsync([FromQuery] GetFilteredBrandsDto dto, CancellationToken cancellationToken)
        {
            var filteredItems = await _catalogBrandService.GetPaginatedAsync(dto, cancellationToken);

            return Ok(filteredItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBrandAsync([FromBody] CreateBrandDto dto, CancellationToken cancellationToken)
        {
            await _catalogBrandService.AddAsync(dto, cancellationToken);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBrandAsync(Guid id, [FromBody] UpdateBrandDto dto, CancellationToken cancellationToken)
        {
            await _catalogBrandService.UpdateAsync(id, dto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBrandAsync(Guid id, CancellationToken cancellationToken)
        {
            await _catalogBrandService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
