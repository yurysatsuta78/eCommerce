using AutoMapper;
using Grpc.Contracts.ProtoBase;
using Orders.Application.Services.Interfaces;
using DTO = Orders.Application.DTOs.Catalog.CatalogItemDTO;

namespace Orders.Infrastructure.Services.Catalog
{
    public class CatalogItemsInfoService : ICatalogItemsInfoService
    {
        private readonly CatalogService.CatalogServiceClient _client;
        private readonly IMapper _mapper;

        public CatalogItemsInfoService(CatalogService.CatalogServiceClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DTO>> GetCatalogItemsByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken)
        {
            var request = new GetCatalogItemsRequest();
            request.ItemIds.AddRange(ids.Select(id => id.ToString()));

            var response = await _client.GetCatalogItemsByIdsAsync(request, cancellationToken: cancellationToken);

            return _mapper.Map<IEnumerable<DTO>>(response.Items);
        }
    }
}
