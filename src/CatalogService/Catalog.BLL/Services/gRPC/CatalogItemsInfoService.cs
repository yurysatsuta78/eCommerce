using AutoMapper;
using Catalog.DAL.Repositories.Interfaces;
using Grpc.Contracts.ProtoBase;
using Grpc.Core;

namespace Catalog.BLL.Services.gRPC
{
    public class CatalogItemsInfoService : CatalogService.CatalogServiceBase
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly IMapper _mapper;

        public CatalogItemsInfoService(ICatalogItemRepository catalogItemRepository, IMapper mapper)
        {
            _catalogItemRepository = catalogItemRepository;
            _mapper = mapper;
        }

        public override async Task<GetCatalogItemsResponse> GetCatalogItemsByIds(GetCatalogItemsRequest request, ServerCallContext context) 
        {
            var cancellationToken = context.CancellationToken;

            var ids = request.ItemIds
                .Where(id => Guid.TryParse(id, out _))
                .Select(id => Guid.Parse(id))
                .ToList();

            var catalogItemsDb = await _catalogItemRepository.GetByIdsAsync(ids, cancellationToken);

            var response = new GetCatalogItemsResponse();

            foreach (var item in catalogItemsDb) 
            {
                response.Items.Add(_mapper.Map<CatalogItemDTO>(item));
            }

            return response;
        }
    }
}