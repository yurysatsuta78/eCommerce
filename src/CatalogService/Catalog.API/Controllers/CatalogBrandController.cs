using Catalog.BLL.DTOs.Request.CatalogBrand;
using Catalog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<IActionResult> GetFilteredBrandsAsync([FromQuery] GetFilteredBrandsRequest filter, 
            CancellationToken cancellationToken)
        {
            var filteredItems = await _catalogBrandService.GetFilteredAsync(filter, cancellationToken);

            return Ok(filteredItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBrandAsync([FromBody] CreateBrandRequest data, CancellationToken cancellationToken)
        {
            await _catalogBrandService.AddAsync(data, cancellationToken);

            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBrandAsync(Guid id, [FromBody] UpdateBrandRequest data, CancellationToken cancellationToken)
        {
            await _catalogBrandService.UpdateAsync(id, data, cancellationToken);

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
