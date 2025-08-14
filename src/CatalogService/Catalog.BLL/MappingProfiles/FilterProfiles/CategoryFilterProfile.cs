using AutoMapper;
using Catalog.BLL.DTOs.CategoryDTOs;
using Catalog.DAL.QueryParams;

namespace Catalog.BLL.MappingProfiles.FilterProfiles
{
    public class CategoryFilterProfile : Profile
    {
        public CategoryFilterProfile() 
        {
            CreateMap<GetFilteredCategoriesDTO, CategoryQueryParams>();
        }
    }
}
