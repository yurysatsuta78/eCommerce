using AutoMapper;
using Catalog.BLL.Dto.Response.CatalogItem;
using Catalog.BLL.Models;
using Catalog.DAL.Models;

namespace Catalog.BLL.MappingProfiles.CatalogItemMappingProfiles
{
    public class CatalogItemProfile : Profile
    {
        public CatalogItemProfile() 
        {
            CreateMap<CatalogItemDb, CatalogItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.AvailableStock, opt => opt.MapFrom(src => src.AvailableStock))
                .ForMember(dest => dest.RestockThreshold, opt => opt.MapFrom(src => src.RestockThreshold))
                .ForMember(dest => dest.MaxStockThreshold, opt => opt.MapFrom(src => src.MaxStockThreshold))
                .ForMember(dest => dest.CatalogBrand, opt => opt.MapFrom(src => src.CatalogBrand))
                .ForMember(dest => dest.CatalogCategory, opt => opt.MapFrom(src => src.CatalogCategory));

            CreateMap<CatalogItem, CatalogItemDb>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.AvailableStock, opt => opt.MapFrom(src => src.AvailableStock))
                .ForMember(dest => dest.RestockThreshold, opt => opt.MapFrom(src => src.RestockThreshold))
                .ForMember(dest => dest.MaxStockThreshold, opt => opt.MapFrom(src => src.MaxStockThreshold))
                .ForMember(dest => dest.CatalogBrandId, opt => opt.MapFrom(src => src.CatalogBrand.Id))
                .ForMember(dest => dest.CatalogCategoryId, opt => opt.MapFrom(src => src.CatalogCategory.Id))
                .ForMember(dest => dest.CatalogBrand, opt => opt.MapFrom(src => src.CatalogBrand))
                .ForMember(dest => dest.CatalogCategory, opt => opt.MapFrom(src => src.CatalogBrand));

            CreateMap<CatalogItem, CatalogItemDto>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.AvailableStock, opt => opt.MapFrom(src => src.AvailableStock));

            CreateMap<CatalogItemDb, CatalogItemDto>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.AvailableStock, opt => opt.MapFrom(src => src.AvailableStock));
        }
    }
}
