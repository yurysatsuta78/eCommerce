using AutoMapper;
using DTO = Orders.Application.DTOs.Catalog.CatalogItemDTO;
using ProtoDTO = Grpc.Contracts.ProtoBase.CatalogItemDTO;

namespace Orders.Infrastructure.MappingProfiles.Catalog
{
    public class CatalogItemProfile : Profile
    {
        public CatalogItemProfile() 
        {
            CreateMap<ProtoDTO, DTO>();
        }
    }
}
