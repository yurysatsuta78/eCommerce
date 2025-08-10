using AutoMapper;
using Catalog.BLL.DTOs.Response.CatalogBrand;
using Catalog.BLL.Models;
using Catalog.DAL.Models;

namespace Catalog.BLL.MappingProfiles.CatalogBrandProfiles
{
    public class CatalogBrandProfile : Profile
    {
        public CatalogBrandProfile() 
        {
            CreateMap<CatalogBrandDb, CatalogBrand>().ReverseMap();

            CreateMap<CatalogBrand, CatalogBrandResponse>();

            CreateMap<CatalogBrandDb, CatalogBrandResponse>();
        }
    }
}
