using AutoMapper;
using Catalog.BLL.DTOs.Request.CatalogBrand;
using Catalog.BLL.DTOs.Response;
using Catalog.BLL.DTOs.Response.CatalogBrand;
using Catalog.BLL.Exceptions;
using Catalog.BLL.Models;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.Models;
using Catalog.DAL.QueryParams;
using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.BLL.Services.Implementations
{
    public class CatalogBrandService : ICatalogBrandService
    {
        private readonly ICatalogBrandRepository _catalogBrandRepository;
        private readonly IMapper _mapper;

        public CatalogBrandService(ICatalogBrandRepository catalogBrandRepository, IMapper mapper) 
        {
            _catalogBrandRepository = catalogBrandRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<CatalogBrandResponse>> GetFilteredAsync(GetFilteredBrandsRequest filter, 
            CancellationToken cancellationToken)
        {
            var queryParams = _mapper.Map<CatalogBrandQueryParams>(filter);

            var dataTask = _catalogBrandRepository.GetFilteredAsync(queryParams, cancellationToken);
            var countTask = _catalogBrandRepository.GetCountAsync(queryParams, cancellationToken);
            await Task.WhenAll(dataTask, countTask);

            var catalogBrandDtos = _mapper.Map<IEnumerable<CatalogBrandResponse>>(dataTask.Result);
            return new PaginatedResponse<CatalogBrandResponse>(catalogBrandDtos, countTask.Result, queryParams.PageNumber, 
                queryParams.PageSize);
        }

        public Task AddAsync(CreateBrandRequest data, CancellationToken cancellationToken)
        {
            var catalogBrandDb = _mapper.Map<CatalogBrandDb>(CatalogBrand.Create(Guid.NewGuid(), data.Name));

            return _catalogBrandRepository.AddAsync(catalogBrandDb, cancellationToken);
        }

        public async Task UpdateAsync(Guid id, UpdateBrandRequest data, CancellationToken cancellationToken)
        {
            var catalogBrandDb = await _catalogBrandRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(CatalogBrandDb)} entity with id: {id} not found.");

            var catalogBrand = _mapper.Map<CatalogBrand>(catalogBrandDb);
            catalogBrand.ChangeName(data.Name);

            await _catalogBrandRepository.UpdateAsync(_mapper.Map<CatalogBrandDb>(catalogBrand), cancellationToken);
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return _catalogBrandRepository.DeleteAsync(id, cancellationToken);
        }
    }
}
