using AutoMapper;
using Orders.Application.DTOs.Order;
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
