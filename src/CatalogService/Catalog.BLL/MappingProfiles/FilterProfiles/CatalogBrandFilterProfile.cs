using AutoMapper;
using Catalog.BLL.DTOs.Request.CatalogBrand;
using Catalog.DAL.QueryParams;

namespace Catalog.BLL.MappingProfiles.FilterProfiles
{
    public class CatalogBrandFilterProfile : Profile
    {
        public CatalogBrandFilterProfile() 
        {
            CreateMap<GetFilteredBrandsRequest, CatalogBrandQueryParams>();
        }
    }
}
