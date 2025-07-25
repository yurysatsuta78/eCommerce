using AutoMapper;
using Catalog.BLL.Dto.Common;
using Catalog.BLL.Dto.Request.CatalogCategory;
using Catalog.BLL.Dto.Response.CatalogCategory;
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

        public async Task<PaginatedResponse<CatalogCategoryDto>> GetPaginatedAsync(GetFilteredCategoriesDto dto, CancellationToken cancellationToken)
        {
            var queryParams = _mapper.Map<CatalogCategoryQueryParams>(dto);

            var dataTask = _catalogCategoryRepository.GetPaginatedAsync(queryParams, cancellationToken);
            var countTask = _catalogCategoryRepository.GetCountAsync(queryParams, cancellationToken);
            await Task.WhenAll(dataTask, countTask);

            var catalogCategoryDtos = _mapper.Map<IEnumerable<CatalogCategoryDto>>(dataTask.Result);
            return new PaginatedResponse<CatalogCategoryDto>(catalogCategoryDtos, countTask.Result, queryParams.PageNumber, queryParams.PageSize);
        }

        public Task AddAsync(CreateCategoryDto dto, CancellationToken cancellationToken)
        {
            var catalogCategoryDb = _mapper.Map<CatalogCategoryDb>(CatalogCategory.Create(Guid.NewGuid(), dto.Name));

            return _catalogCategoryRepository.AddAsync(catalogCategoryDb, cancellationToken);
        }

        public async Task UpdateAsync(Guid id, UpdateCategoryDto dto, CancellationToken cancellationToken)
        {
            var catalogCategoryDb = await _catalogCategoryRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(CatalogCategoryDb)} entity with id: {id} not found.");

            var catalogCategory = _mapper.Map<CatalogCategory>(catalogCategoryDb);
            catalogCategory.ChangeName(dto.Name);

            await _catalogCategoryRepository.UpdateAsync(_mapper.Map<CatalogCategoryDb>(catalogCategory), cancellationToken);
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return _catalogCategoryRepository.DeleteAsync(id, cancellationToken);
        }
    }
}
