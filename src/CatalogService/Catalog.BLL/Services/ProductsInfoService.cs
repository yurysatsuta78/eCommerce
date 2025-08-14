using AutoMapper;
using Catalog.DAL.Repositories.Interfaces;
using Contracts.ProtoBase;
using Grpc.Core;

namespace Catalog.BLL.Services
{
    public class ProductsInfoService : CatalogService.CatalogServiceBase
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public ProductsInfoService(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public override async Task<GetProductsResponse> GetProductsByIds(GetProductsRequest request, ServerCallContext context) 
        {
            var cancellationToken = context.CancellationToken;

            var ids = request.ProductIds
                .Where(id => Guid.TryParse(id, out _))
                .Select(id => Guid.Parse(id))
                .ToList();

            var itemsDb = await _productsRepository.GetByIdsAsync(ids, cancellationToken);

            var response = new GetProductsResponse();

            foreach (var item in itemsDb) 
            {
                response.Items.Add(_mapper.Map<ProductInfoDTO>(item));
            }

            return response;
        }
    }
}