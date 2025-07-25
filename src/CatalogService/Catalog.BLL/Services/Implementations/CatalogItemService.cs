using AutoMapper;
using Catalog.BLL.Dto.Common;
using Catalog.BLL.Dto.Request.CatalogItem;
using Catalog.BLL.Dto.Response.CatalogItem;
using Catalog.BLL.Exceptions;
using Catalog.BLL.Models;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.Models;
using Catalog.DAL.QueryParams;
using Catalog.DAL.Repositories.Interfaces;
using AddStockRequest = Catalog.BLL.Dto.Request.CatalogItem.AddStockDto;
using AddStockResponse = Catalog.BLL.Dto.Response.CatalogItem.AddStockDto;
using RemoveStockRequest = Catalog.BLL.Dto.Request.CatalogItem.RemoveStockDto;
using RemoveStockResponse = Catalog.BLL.Dto.Response.CatalogItem.RemoveStockDto;

namespace Catalog.BLL.Services.Implementations
{
    public class CatalogItemService : ICatalogItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CatalogItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<CatalogItemDto>> GetPaginatedAsync(GetFilteredCatalogItemsDto dto, CancellationToken cancellationToken)
        {
            var queryParams = _mapper.Map<CatalogItemQueryParams>(dto);

            var dataTask = _unitOfWork.CatalogItemRepository.GetPaginatedAsync(queryParams, cancellationToken);
            var countTask = _unitOfWork.CatalogItemRepository.GetCountAsync(queryParams, cancellationToken);
            await Task.WhenAll(dataTask, countTask);

            var catalogItemDtos = _mapper.Map<IEnumerable<CatalogItemDto>>(dataTask.Result);
            return new PaginatedResponse<CatalogItemDto>(catalogItemDtos, countTask.Result, dto.PageNumber, dto.PageSize);
        }

        public async Task AddAsync(CreateCatalogItemDto dto, CancellationToken cancellationToken)
        {
            var catalogBrandDb = await _unitOfWork.CatalogBrandRepository.GetByIdAsync(dto.BrandId, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(CatalogBrandDb)} entity with id: {dto.BrandId} not found.");
            var catalogBrand = _mapper.Map<CatalogBrand>(catalogBrandDb);

            var catalogCategoryDb = await _unitOfWork.CatalogCategoryRepository.GetByIdAsync(dto.CategoryId, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(CatalogCategoryDb)} entity with id: {dto.CategoryId} not found.");
            var catalogCategory = _mapper.Map<CatalogCategory>(catalogCategoryDb);

            var catalogItemDb = _mapper.Map<CatalogItemDb>(CatalogItem.Create(Guid.NewGuid(), dto.Name, dto.Description, dto.Price,
                dto.RestockThreshold, dto.MaxStockThreshold, catalogBrand, catalogCategory));

            await _unitOfWork.CatalogItemRepository.AddAsync(catalogItemDb, cancellationToken);
        }

        public async Task UpdateAsync(Guid id, UpdateCatalogItemDto dto, CancellationToken cancellationToken)
        {
            var catalogItemDb = await _unitOfWork.CatalogItemRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(CatalogItemDb)} entity with id: {id} not found.");
            var catalogItem = _mapper.Map<CatalogItem>(catalogItemDb);

            catalogItem.ChangeName(dto.Name);
            catalogItem.ChangeDescription(dto.Description);
            catalogItem.ChangePrice(dto.Price);

            await _unitOfWork.CatalogItemRepository.UpdateAsync(_mapper.Map<CatalogItemDb>(catalogItem), cancellationToken);
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return _unitOfWork.CatalogItemRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task<AddStockResponse> AddStockAsync(Guid id, AddStockRequest dto, CancellationToken cancellationToken)
        {
            var catalogItemDb = await _unitOfWork.CatalogItemRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(CatalogItemDb)} entity with id: {id} not found.");
            var catalogItem = _mapper.Map<CatalogItem>(catalogItemDb);

            var quantityAdded = catalogItem.AddStock(dto.Quantity);
            await _unitOfWork.CatalogItemRepository.UpdateAsync(_mapper.Map<CatalogItemDb>(catalogItem), cancellationToken);

            return new AddStockResponse(quantityAdded, catalogItem.AvailableStock);
        }

        public async Task<RemoveStockResponse> RemoveStockAsync(Guid id, RemoveStockRequest dto, CancellationToken cancellationToken)
        {
            var catalogItemDb = await _unitOfWork.CatalogItemRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(CatalogItemDb)} entity with id: {id} not found.");
            var catalogItem = _mapper.Map<CatalogItem>(catalogItemDb);

            var quantityRemoved = catalogItem.RemoveStock(dto.QuantityDesired);
            await _unitOfWork.CatalogItemRepository.UpdateAsync(_mapper.Map<CatalogItemDb>(catalogItem), cancellationToken);

            return new RemoveStockResponse(quantityRemoved, catalogItem.AvailableStock);
        }
    }
}
