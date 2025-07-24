using AutoMapper;
using Catalog.BLL.Dto.Responce.CatalogItem;
using Catalog.BLL.Models;

namespace Catalog.BLL.MappingProfiles.CatalogItemMappingProfiles
{
    public class CatalogItemDtoDomainProfile : Profile
    {
        public CatalogItemDtoDomainProfile() 
        {
            CreateMap<CatalogItem, CatalogItemDto>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.AvailableStock, opt => opt.MapFrom(src => src.AvailableStock));
        }
    }
}
