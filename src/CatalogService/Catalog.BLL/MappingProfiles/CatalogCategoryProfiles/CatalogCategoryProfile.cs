using AutoMapper;
using Catalog.BLL.Dto.Response.CatalogCategory;
using Catalog.BLL.Models;
using Catalog.DAL.Models;

namespace Catalog.BLL.MappingProfiles.CatalogCategoryProfiles
{
    public class CatalogCategoryProfile : Profile
    {
        public CatalogCategoryProfile() 
        {
            CreateMap<CatalogCategoryDb, CatalogCategory>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CatalogCategory, CatalogCategoryDb>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CatalogCategory, CatalogCategoryDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CatalogCategoryDb, CatalogCategoryDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
