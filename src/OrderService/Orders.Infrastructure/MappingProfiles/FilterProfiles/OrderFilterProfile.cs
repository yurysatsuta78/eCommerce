using AutoMapper;
using Orders.Application.DTOs.Request;
using Orders.Domain.QueryParams;

namespace Orders.Infrastructure.MappingProfiles.FilterProfiles
{
    public class OrderFilterProfile : Profile
    {
        public OrderFilterProfile() 
        {
            CreateMap<GetFilteredOrdersRequest, OrderFilterParams>();
        }
    }
}
