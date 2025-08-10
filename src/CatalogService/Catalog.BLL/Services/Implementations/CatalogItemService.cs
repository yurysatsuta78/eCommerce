using AutoMapper;
using Catalog.BLL.DTOs.Request.CatalogItem;
using Catalog.BLL.DTOs.Response;
using Catalog.BLL.DTOs.Response.CatalogItem;
using Catalog.BLL.Exceptions;
using Catalog.BLL.Models;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.Models;
using Catalog.DAL.QueryParams;
using Catalog.DAL.Repositories.Interfaces;
using AddStockRequest = Catalog.BLL.DTOs.Request.CatalogItem.AddStockRequest;
using AddStockResponse = Catalog.BLL.DTOs.Response.CatalogItem.AddStockResponse;
using RemoveStockRequest = Catalog.BLL.DTOs.Request.CatalogItem.RemoveStockRequest;
using RemoveStockResponse = Catalog.BLL.DTOs.Response.CatalogItem.RemoveStockResponse;

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

        public async Task<PaginatedResponse<CatalogItemResponse>> GetFilteredAsync(GetFilteredCatalogItemsRequest filter, 
            CancellationToken cancellationToken)
        {
            var queryParams = _mapper.Map<CatalogItemQueryParams>(filter);

            var dataTask = _unitOfWork.CatalogItemRepository.GetFilteredAsync(queryParams, cancellationToken);
            var countTask = _unitOfWork.CatalogItemRepository.GetCountAsync(queryParams, cancellationToken);
            await Task.WhenAll(dataTask, countTask);

            var catalogItemDtos = _mapper.Map<IEnumerable<CatalogItemResponse>>(dataTask.Result);
            return new PaginatedResponse<CatalogItemResponse>(catalogItemDtos, countTask.Result, queryParams.PageNumber, 
                queryParams.PageSize);
        }

        public async Task AddAsync(CreateCatalogItemRequest data, CancellationToken cancellationToken)
        {
            var catalogBrandDb = await _unitOfWork.CatalogBrandRepository.GetByIdAsync(data.BrandId, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(CatalogBrandDb)} entity with id: {data.BrandId} not found.");
            var catalogBrand = _mapper.Map<CatalogBrand>(catalogBrandDb);

            var catalogCategoryDb = await _unitOfWork.CatalogCategoryRepository.GetByIdAsync(data.CategoryId, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(CatalogCategoryDb)} entity with id: {data.CategoryId} not found.");
            var catalogCategory = _mapper.Map<CatalogCategory>(catalogCategoryDb);

            var catalogItemDb = _mapper.Map<CatalogItemDb>(CatalogItem.Create(Guid.NewGuid(), data.Name, data.Description, data.Price,
                data.RestockThreshold, data.MaxStockThreshold, catalogBrand, catalogCategory));

            await _unitOfWork.CatalogItemRepository.AddAsync(catalogItemDb, cancellationToken);
        }

        public async Task UpdateAsync(Guid id, UpdateCatalogItemRequest data, CancellationToken cancellationToken)
        {
            var catalogItemDb = await _unitOfWork.CatalogItemRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(CatalogItemDb)} entity with id: {id} not found.");
            var catalogItem = _mapper.Map<CatalogItem>(catalogItemDb);

            catalogItem.ChangeName(data.Name);
            catalogItem.ChangeDescription(data.Description);
            catalogItem.ChangePrice(data.Price);

            await _unitOfWork.CatalogItemRepository.UpdateAsync(_mapper.Map<CatalogItemDb>(catalogItem), cancellationToken);
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return _unitOfWork.CatalogItemRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task<AddStockResponse> AddStockAsync(Guid id, AddStockRequest data, CancellationToken cancellationToken)
        {
            var catalogItemDb = await _unitOfWork.CatalogItemRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(CatalogItemDb)} entity with id: {id} not found.");
            var catalogItem = _mapper.Map<CatalogItem>(catalogItemDb);

            var quantityAdded = catalogItem.AddStock(data.Quantity);
            await _unitOfWork.CatalogItemRepository.UpdateAsync(_mapper.Map<CatalogItemDb>(catalogItem), cancellationToken);

            return new AddStockResponse(quantityAdded, catalogItem.AvailableStock);
        }

        public async Task<RemoveStockResponse> RemoveStockAsync(Guid id, RemoveStockRequest data, CancellationToken cancellationToken)
        {
            var catalogItemDb = await _unitOfWork.CatalogItemRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(CatalogItemDb)} entity with id: {id} not found.");
            var catalogItem = _mapper.Map<CatalogItem>(catalogItemDb);

            var quantityRemoved = catalogItem.RemoveStock(data.QuantityDesired);
            await _unitOfWork.CatalogItemRepository.UpdateAsync(_mapper.Map<CatalogItemDb>(catalogItem), cancellationToken);

            return new RemoveStockResponse(quantityRemoved, catalogItem.AvailableStock);
        }
    }
}
