using AutoMapper;
using Orders.Application.DTOs.Order;
using Orders.Domain.QueryParams;

namespace Orders.Infrastructure.MappingProfiles.Order
{
    public class OrderFilterParamsProfile : Profile
    {
        public OrderFilterParamsProfile() 
        {
            CreateMap<OrderFilterParamsDTO, OrderFilterParams>();
        }
    }
}
