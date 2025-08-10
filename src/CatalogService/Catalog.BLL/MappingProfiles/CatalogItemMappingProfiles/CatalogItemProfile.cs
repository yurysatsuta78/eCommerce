using AutoMapper;
using Catalog.BLL.DTOs.Response.CatalogItem;
using Catalog.BLL.Models;
using Catalog.DAL.Models;

namespace Catalog.BLL.MappingProfiles.CatalogItemMappingProfiles
{
    public class CatalogItemProfile : Profile
    {
        public CatalogItemProfile() 
        {
            CreateMap<CatalogItemDb, CatalogItem>();

            CreateMap<CatalogItem, CatalogItemDb>()
                .ForMember(dest => dest.CatalogBrandId, opt => opt.MapFrom(src => src.CatalogBrand.Id))
                .ForMember(dest => dest.CatalogCategoryId, opt => opt.MapFrom(src => src.CatalogCategory.Id));

            CreateMap<CatalogItem, CatalogItemResponse>();

            CreateMap<CatalogItemDb, CatalogItemResponse>();
        }
    }
}
