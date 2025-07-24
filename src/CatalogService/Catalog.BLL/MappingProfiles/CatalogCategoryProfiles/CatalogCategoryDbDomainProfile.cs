using AutoMapper;
using Catalog.BLL.Models;
using Catalog.DAL.Models;

namespace Catalog.BLL.MappingProfiles.CatalogCategoryProfiles
{
    public class CatalogCategoryDbDomainProfile : Profile
    {
        public CatalogCategoryDbDomainProfile() 
        {
            CreateMap<CatalogCategoryDb, CatalogCategory>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CatalogCategory, CatalogCategoryDb>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
