using AutoMapper;
using Catalog.BLL.DTOs.Request.CatalogCategory;
using Catalog.BLL.DTOs.Response;
using Catalog.BLL.DTOs.Response.CatalogCategory;
using Catalog.BLL.Exceptions;
using Catalog.BLL.Models;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.Models;
using Catalog.DAL.QueryParams;
using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.BLL.Services.Implementations
{
    public class CatalogCategoryService : ICatalogCategoryService
    {
        private readonly ICatalogCategoryRepository _catalogCategoryRepository;
        private readonly IMapper _mapper;

        public CatalogCategoryService(ICatalogCategoryRepository catalogCategoryRepository, IMapper mapper)
        {
            _catalogCategoryRepository = catalogCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<CatalogCategoryResponse>> GetFilteredAsync(GetFilteredCategoriesRequest filter, 
            CancellationToken cancellationToken)
        {
            var queryParams = _mapper.Map<CatalogCategoryQueryParams>(filter);

            var dataTask = _catalogCategoryRepository.GetFilteredAsync(queryParams, cancellationToken);
            var countTask = _catalogCategoryRepository.GetCountAsync(queryParams, cancellationToken);
            await Task.WhenAll(dataTask, countTask);

            var catalogCategoryDtos = _mapper.Map<IEnumerable<CatalogCategoryResponse>>(dataTask.Result);
            return new PaginatedResponse<CatalogCategoryResponse>(catalogCategoryDtos, countTask.Result, queryParams.PageNumber, 
                queryParams.PageSize);
        }

        public Task AddAsync(CreateCategoryRequest data, CancellationToken cancellationToken)
        {
            var catalogCategoryDb = _mapper.Map<CatalogCategoryDb>(CatalogCategory.Create(Guid.NewGuid(), data.Name));

            return _catalogCategoryRepository.AddAsync(catalogCategoryDb, cancellationToken);
        }

        public async Task UpdateAsync(Guid id, UpdateCategoryRequest data, CancellationToken cancellationToken)
        {
            var catalogCategoryDb = await _catalogCategoryRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(CatalogCategoryDb)} entity with id: {id} not found.");

            var catalogCategory = _mapper.Map<CatalogCategory>(catalogCategoryDb);
            catalogCategory.ChangeName(data.Name);

            await _catalogCategoryRepository.UpdateAsync(_mapper.Map<CatalogCategoryDb>(catalogCategory), cancellationToken);
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return _catalogCategoryRepository.DeleteAsync(id, cancellationToken);
        }
    }
}
