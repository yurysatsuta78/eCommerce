using AutoMapper;
using Catalog.BLL.DTOs.BrandDTOs;
using Catalog.BLL.Models;
using Catalog.DAL.Models;

namespace Catalog.BLL.MappingProfiles.BrandProfiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile() 
        {
            CreateMap<BrandDb, Brand>().ReverseMap();

            CreateMap<Brand, BrandDTO>();

            CreateMap<BrandDb, BrandDTO>();
        }
    }
}
