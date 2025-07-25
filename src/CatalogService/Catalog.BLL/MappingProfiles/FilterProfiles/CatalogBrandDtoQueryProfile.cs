using AutoMapper;
using Catalog.BLL.Dto.Request.CatalogBrand;
using Catalog.DAL.QueryParams;

namespace Catalog.BLL.MappingProfiles.FilterProfiles
{
    public class CatalogBrandDtoQueryProfile : Profile
    {
        public CatalogBrandDtoQueryProfile() 
        {
            CreateMap<GetFilteredBrandsDto, CatalogBrandQueryParams>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.PageNumber))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize));
        }
    }
}
