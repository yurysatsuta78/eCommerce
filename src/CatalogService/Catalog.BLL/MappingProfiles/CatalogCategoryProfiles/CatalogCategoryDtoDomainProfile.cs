using AutoMapper;
using Catalog.BLL.Dto.Responce.CatalogCategory;
using Catalog.BLL.Models;

namespace Catalog.BLL.MappingProfiles.CatalogCategoryProfiles
{
    public class CatalogCategoryDtoDomainProfile : Profile
    {
        public CatalogCategoryDtoDomainProfile() 
        {
            CreateMap<CatalogCategory, CatalogCategoryDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
