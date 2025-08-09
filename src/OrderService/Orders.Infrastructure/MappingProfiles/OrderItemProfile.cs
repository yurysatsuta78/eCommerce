using AutoMapper;
using Orders.Application.DTOs.Response;
using Orders.Domain.Models;

namespace Orders.Infrastructure.MappingProfiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile() 
        {
            CreateMap<OrderItem, OrderItemResponse>();
        }
    }
}
