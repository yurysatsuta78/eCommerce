using AutoMapper;
using OrderDTO = Orders.Application.DTOs.OrderDTOs.OrderDTO;
using OrderDomain = Orders.Domain.Models.Order;

namespace Orders.Infrastructure.MappingProfiles.Order
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        {
            CreateMap<OrderDomain, OrderDTO>();
        }
    }
}
