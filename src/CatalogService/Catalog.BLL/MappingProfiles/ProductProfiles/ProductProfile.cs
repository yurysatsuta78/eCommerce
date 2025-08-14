using AutoMapper;
using Catalog.BLL.DTOs.ProductDTOs;
using Catalog.BLL.Models;
using Catalog.DAL.Models;
using Contracts.ProtoBase;

namespace Catalog.BLL.MappingProfiles.ProductProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<ProductDb, Product>();

            CreateMap<Product, ProductDb>()
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Brand.Id))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id));

            CreateMap<Product, ProductDTO>();

            CreateMap<ProductDb, ProductDTO>()
                .ForMember(dest => dest.AvailableStock, opt => opt.MapFrom(src => src.InStock - src.ReservedStock));

            CreateMap<ProductDb, ProductInfoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => Convert.ToDouble(src.Price)))
                .ForMember(dest => dest.AvailableStock, opt => opt.MapFrom(src => src.InStock - src.ReservedStock));
        }
    }
}
