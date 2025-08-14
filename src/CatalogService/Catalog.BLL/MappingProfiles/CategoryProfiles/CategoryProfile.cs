using AutoMapper;
using Catalog.BLL.DTOs.CategoryDTOs;
using Catalog.BLL.Models;
using Catalog.DAL.Models;

namespace Catalog.BLL.MappingProfiles.CategoryProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<CategoryDb, Category>().ReverseMap();

            CreateMap<Category, CategoryDTO>();

            CreateMap<CategoryDb, CategoryDTO>();
        }
    }
}
