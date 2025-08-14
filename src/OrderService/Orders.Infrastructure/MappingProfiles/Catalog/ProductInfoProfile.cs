using AutoMapper;
using DTO = Orders.Application.DTOs.CatalogDTOs.ProductInfoDTO;
using ProtoDTO = Contracts.ProtoBase.ProductInfoDTO;

namespace Orders.Infrastructure.MappingProfiles.Catalog
{
    public class ProductInfoProfile : Profile
    {
        public ProductInfoProfile() 
        {
            CreateMap<ProtoDTO, DTO>();
        }
    }
}
