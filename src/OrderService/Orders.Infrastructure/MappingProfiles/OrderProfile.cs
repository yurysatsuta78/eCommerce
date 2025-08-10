using AutoMapper;
using Orders.Application.DTOs.Response;
using Orders.Domain.Models;

namespace Orders.Infrastructure.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        {
            CreateMap<Order, OrderResponse>();
        }
    }
}
