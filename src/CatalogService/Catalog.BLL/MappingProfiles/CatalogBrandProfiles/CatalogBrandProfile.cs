using AutoMapper;
using Catalog.BLL.Dto.Response.CatalogBrand;
using Catalog.BLL.Models;
using Catalog.DAL.Models;

namespace Catalog.BLL.MappingProfiles.CatalogBrandProfiles
{
    public class CatalogBrandProfile : Profile
    {
        public CatalogBrandProfile() 
        {
            CreateMap<CatalogBrandDb, CatalogBrand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CatalogBrand, CatalogBrandDb>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CatalogBrand, CatalogBrandDto>()
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CatalogBrandDb, CatalogBrandDto>()
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
