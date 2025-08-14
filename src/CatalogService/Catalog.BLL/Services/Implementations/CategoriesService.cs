using AutoMapper;
using Catalog.BLL.DTOs.CategoryDTOs;
using Catalog.BLL.DTOs.Common;
using Catalog.BLL.Exceptions;
using Catalog.BLL.Models;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.Models;
using Catalog.DAL.QueryParams;
using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.BLL.Services.Implementations
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;

        public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedEntities<CategoryDTO>> GetFilteredAsync(GetFilteredCategoriesDTO dto, 
            CancellationToken cancellationToken)
        {
            var queryParams = _mapper.Map<CategoryQueryParams>(dto);

            var dataTask = _categoriesRepository.GetFilteredAsync(queryParams, cancellationToken);
            var countTask = _categoriesRepository.GetCountAsync(queryParams, cancellationToken);
            await Task.WhenAll(dataTask, countTask);

            var categoryDtos = _mapper.Map<IEnumerable<CategoryDTO>>(dataTask.Result);
            return new PaginatedEntities<CategoryDTO>(categoryDtos, countTask.Result, queryParams.PageNumber, 
                queryParams.PageSize);
        }

        public Task AddAsync(CreateCategoryDTO dto, CancellationToken cancellationToken)
        {
            var categoryDb = _mapper.Map<CategoryDb>(Category.Create(Guid.NewGuid(), dto.Name));

            return _categoriesRepository.AddAsync(categoryDb, cancellationToken);
        }

        public async Task UpdateAsync(Guid id, UpdateCategoryDTO dto, CancellationToken cancellationToken)
        {
            var categoryDb = await _categoriesRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(CategoryDb)} entity with id: {id} not found.");

            var category = _mapper.Map<Category>(categoryDb);
            category.ChangeName(dto.Name);

            await _categoriesRepository.UpdateAsync(_mapper.Map<CategoryDb>(category), cancellationToken);
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return _categoriesRepository.DeleteAsync(id, cancellationToken);
        }
    }
}
