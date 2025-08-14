using AutoMapper;
using Orders.Application.DTOs.OrderDTOs;
using Orders.Domain.Models;

namespace Orders.Infrastructure.MappingProfiles.Order
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile() 
        {
            CreateMap<OrderItem, OrderItemDTO>();
        }
    }
}
