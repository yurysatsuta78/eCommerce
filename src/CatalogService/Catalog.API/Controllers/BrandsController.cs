using Catalog.BLL.DTOs.BrandDTOs;
using Catalog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandsService _brandsService;

        public BrandsController(IBrandsService brandsService)
        {
            _brandsService = brandsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredBrandsAsync([FromQuery] GetFilteredBrandsDTO dto, 
            CancellationToken cancellationToken)
        {
            var filteredBrands = await _brandsService.GetFilteredAsync(dto, cancellationToken);

            return Ok(filteredBrands);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBrandAsync([FromBody] CreateBrandDTO dto, CancellationToken cancellationToken)
        {
            await _brandsService.AddAsync(dto, cancellationToken);

            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBrandAsync(Guid id, [FromBody] UpdateBrandDTO dto, CancellationToken cancellationToken)
        {
            await _brandsService.UpdateAsync(id, dto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBrandAsync(Guid id, CancellationToken cancellationToken)
        {
            await _brandsService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
