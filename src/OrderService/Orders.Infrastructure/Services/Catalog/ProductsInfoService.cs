using AutoMapper;
using Contracts.ProtoBase;
using Orders.Application.Services.Interfaces;
using DTO = Orders.Application.DTOs.CatalogDTOs.ProductInfoDTO;

namespace Orders.Infrastructure.Services.Catalog
{
    public class ProductsInfoService : IProductsInfoService
    {
        private readonly CatalogService.CatalogServiceClient _client;
        private readonly IMapper _mapper;

        public ProductsInfoService(CatalogService.CatalogServiceClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DTO>> GetProductsByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken)
        {
            var request = new GetProductsRequest();
            request.ProductIds.AddRange(ids.Select(id => id.ToString()));

            var response = await _client.GetProductsByIdsAsync(request, cancellationToken: cancellationToken);

            return _mapper.Map<IEnumerable<DTO>>(response.Items);
        }
    }
}
