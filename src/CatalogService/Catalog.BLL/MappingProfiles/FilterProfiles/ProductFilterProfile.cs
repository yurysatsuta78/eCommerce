using AutoMapper;
using Catalog.BLL.DTOs.ProductDTOs;
using Catalog.DAL.QueryParams;

namespace Catalog.BLL.MappingProfiles.FilterProfiles
{
    public class ProductFilterProfile : Profile
    {
        public ProductFilterProfile() 
        {
            CreateMap<GetFilteredProductsDTO, ProductQueryParams>();
        }
    }
}
