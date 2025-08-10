using AutoMapper;
using Catalog.BLL.DTOs.Response.CatalogCategory;
using Catalog.BLL.Models;
using Catalog.DAL.Models;

namespace Catalog.BLL.MappingProfiles.CatalogCategoryProfiles
{
    public class CatalogCategoryProfile : Profile
    {
        public CatalogCategoryProfile() 
        {
            CreateMap<CatalogCategoryDb, CatalogCategory>().ReverseMap();

            CreateMap<CatalogCategory, CatalogCategoryResponse>();

            CreateMap<CatalogCategoryDb, CatalogCategoryResponse>();
        }
    }
}
