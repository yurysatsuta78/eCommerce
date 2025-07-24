using AutoMapper;
using Catalog.BLL.Dto.Responce.CatalogBrand;
using Catalog.BLL.Models;

namespace Catalog.BLL.MappingProfiles.CatalogBrandProfiles
{
    public class CatalogBrandDtoDomainProfile : Profile
    {
        public CatalogBrandDtoDomainProfile() 
        {
            CreateMap<CatalogBrand, CatalogBrandDto>()
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
