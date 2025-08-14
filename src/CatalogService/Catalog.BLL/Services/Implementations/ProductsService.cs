using AutoMapper;
using Catalog.BLL.DTOs.Common;
using Catalog.BLL.DTOs.ProductDTOs;
using Catalog.BLL.DTOs.ProductDTOs.Stock;
using Catalog.BLL.Exceptions;
using Catalog.BLL.Models;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.Models;
using Catalog.DAL.QueryParams;
using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.BLL.Services.Implementations
{
    public class ProductsService : IProductsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedEntities<ProductDTO>> GetFilteredAsync(GetFilteredProductsDTO dto, 
            CancellationToken cancellationToken)
        {
            var queryParams = _mapper.Map<ProductQueryParams>(dto);

            var dataTask = _unitOfWork.ProductsRepository.GetFilteredAsync(queryParams, cancellationToken);
            var countTask = _unitOfWork.ProductsRepository.GetCountAsync(queryParams, cancellationToken);
            await Task.WhenAll(dataTask, countTask);

            var productDtos = _mapper.Map<IEnumerable<ProductDTO>>(dataTask.Result);
            return new PaginatedEntities<ProductDTO>(productDtos, countTask.Result, queryParams.PageNumber, 
                queryParams.PageSize);
        }

        public async Task AddAsync(CreateProductDTO dto, CancellationToken cancellationToken)
        {
            var brandDb = await _unitOfWork.BrandsRepository.GetByIdAsync(dto.BrandId, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(BrandDb)} entity with id: {dto.BrandId} not found.");
            var brand = _mapper.Map<Brand>(brandDb);

            var categoryDb = await _unitOfWork.CategoriesRepository.GetByIdAsync(dto.CategoryId, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(CategoryDb)} entity with id: {dto.CategoryId} not found.");
            var category = _mapper.Map<Category>(categoryDb);

            var productDb = _mapper.Map<ProductDb>(Product.Create(Guid.NewGuid(), dto.Name, dto.Description, dto.Price,
                dto.StockCapacity, brand, category));

            await _unitOfWork.ProductsRepository.AddAsync(productDb, cancellationToken);
        }

        public async Task UpdateAsync(Guid id, UpdateProductDTO dto, CancellationToken cancellationToken)
        {
            var productDb = await _unitOfWork.ProductsRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(ProductDb)} entity with id: {id} not found.");
            var product = _mapper.Map<Product>(productDb);

            product.ChangeName(dto.Name);
            product.ChangeDescription(dto.Description);
            product.ChangePrice(dto.Price);

            await _unitOfWork.ProductsRepository.UpdateAsync(_mapper.Map<ProductDb>(product), cancellationToken);
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return _unitOfWork.ProductsRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task AddStockAsync(Guid id, AddStockDTO dto, CancellationToken cancellationToken)
        {
            var productDb = await _unitOfWork.ProductsRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(ProductDb)} entity with id: {id} not found.");
            var product = _mapper.Map<Product>(productDb);

            product.AddStock(dto.Quantity);
            await _unitOfWork.ProductsRepository.UpdateAsync(_mapper.Map<ProductDb>(product), cancellationToken);
        }

        public async Task RemoveStockAsync(Guid id, RemoveStockDTO dto, CancellationToken cancellationToken)
        {
            var productDb = await _unitOfWork.ProductsRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new EntityNotFoundException($"{typeof(ProductDb)} entity with id: {id} not found.");
            var product = _mapper.Map<Product>(productDb);

            product.RemoveStock(dto.Quantity);
            await _unitOfWork.ProductsRepository.UpdateAsync(_mapper.Map<ProductDb>(product), cancellationToken);
        }
    }
}
