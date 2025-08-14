using AutoMapper;
using Orders.Application.DTOs.OrderDTOs;
using Orders.Domain.QueryParams;

namespace Orders.Infrastructure.MappingProfiles.Order
{
    public class OrderFilterProfile : Profile
    {
        public OrderFilterProfile() 
        {
            CreateMap<GetFilteredOrdersDTO, OrderFilterParams>();
        }
    }
}
