using AutoMapper;
using Catalog.BLL.DTOs.Request.CatalogItem;
using Catalog.DAL.QueryParams;

namespace Catalog.BLL.MappingProfiles.FilterProfiles
{
    public class CatalogItemFilterProfile : Profile
    {
        public CatalogItemFilterProfile() 
        {
            CreateMap<GetFilteredCatalogItemsRequest, CatalogItemQueryParams>();
        }
    }
}
