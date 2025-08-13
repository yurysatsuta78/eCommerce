using AutoMapper;
using Catalog.BLL.Dto.Request.CatalogItem;
using Catalog.DAL.QueryParams;

namespace Catalog.BLL.MappingProfiles.FilterProfiles
{
    public class CatalogItemDtoQueryProfile : Profile
    {
        public CatalogItemDtoQueryProfile() 
        {
            CreateMap<GetFilteredCatalogItemsDto, CatalogItemQueryParams>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.MinPrice, opt => opt.MapFrom(src => src.MinPrice))
                .ForMember(dest => dest.MaxPrice, opt => opt.MapFrom(src => src.MaxPrice))
                .ForMember(dest => dest.InStockOnly, opt => opt.MapFrom(src => src.InStockOnly))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BrandId))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.PageNumber))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize));
        }
    }
}
