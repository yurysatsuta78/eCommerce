using AutoMapper;
using Catalog.BLL.DTOs.BrandDTOs;
using Catalog.DAL.QueryParams;

namespace Catalog.BLL.MappingProfiles.FilterProfiles
{
    public class BrandFilterProfile : Profile
    {
        public BrandFilterProfile() 
        {
            CreateMap<GetFilteredBrandsDTO, BrandQueryParams>();
        }
    }
}
