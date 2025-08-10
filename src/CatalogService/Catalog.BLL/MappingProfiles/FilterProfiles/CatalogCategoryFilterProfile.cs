using AutoMapper;
using Catalog.BLL.DTOs.Request.CatalogCategory;
using Catalog.DAL.QueryParams;

namespace Catalog.BLL.MappingProfiles.FilterProfiles
{
    public class CatalogCategoryFilterProfile : Profile
    {
        public CatalogCategoryFilterProfile() 
        {
            CreateMap<GetFilteredCategoriesRequest, CatalogCategoryQueryParams>();
        }
    }
}
