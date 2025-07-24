using AutoMapper;
using Catalog.BLL.Models;
using Catalog.DAL.Models;

namespace Catalog.BLL.MappingProfiles.CatalogBrandProfiles
{
    public class CatalogBrandDbDomainProfile : Profile
    {
        public CatalogBrandDbDomainProfile() 
        {
            CreateMap<CatalogBrandDb, CatalogBrand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CatalogBrand, CatalogBrandDb>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
