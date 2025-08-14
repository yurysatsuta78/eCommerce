using AutoMapper;
using Catalog.BLL.DTOs.BrandDTOs;
using Catalog.BLL.DTOs.Common;
using Catalog.BLL.Exceptions;
using Catalog.BLL.Models;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.Models;
using Catalog.DAL.QueryParams;
using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.BLL.Services.Implementations
{
    public class BrandsService : IBrandsService
    {
        private readonly IBrandsRepository _brandsRepository;
        private readonly IMapper _mapper;

        public BrandsService(IBrandsRepository brandsRepository, IMapper mapper) 
        {
            _brandsRepository = brandsRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedEntities<BrandDTO>> GetFilteredAsync(GetFilteredBrandsDTO filter, 
            CancellationToken cancellationToken)
        {
            var queryParams = _mapper.Map<BrandQueryParams>(filter);

            var dataTask = _brandsRepository.GetFilteredAsync(queryParams, cancellationToken);
            var countTask = _brandsRepository.GetCountAsync(queryParams, cancellationToken);
            await Task.WhenAll(dataTask, countTask);

            var brandDtos = _mapper.Map<IEnumerable<BrandDTO>>(dataTask.Result);
            return new PaginatedEntities<BrandDTO>(brandDtos, countTask.Result, queryParams.PageNumber, 
                queryParams.PageSize);
        }

        public Task AddAsync(CreateBrandDTO dto, CancellationToken cancellationToken)
        {
            var brandDb = _mapper.Map<BrandDb>(Brand.Create(Guid.NewGuid(), dto.Name));

            return _brandsRepository.AddAsync(brandDb, cancellationToken);
        }

        public async Task UpdateAsync(Guid id, UpdateBrandDTO dto, CancellationToken cancellationToken)
        {
            var brandDb = await _brandsRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(BrandDb)} entity with id: {id} not found.");

            var brand = _mapper.Map<Brand>(brandDb);
            brand.ChangeName(dto.Name);

            await _brandsRepository.UpdateAsync(_mapper.Map<BrandDb>(brand), cancellationToken);
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return _brandsRepository.DeleteAsync(id, cancellationToken);
        }
    }
}
