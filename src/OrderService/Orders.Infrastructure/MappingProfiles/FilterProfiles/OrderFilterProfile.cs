using AutoMapper;
using Orders.Application.Dto.Request;
using Orders.Domain.QueryParams;

namespace Orders.Infrastructure.MappingProfiles.FilterProfiles
{
    public class OrderFilterProfile : Profile
    {
        public OrderFilterProfile() 
        {
            CreateMap<GetFilteredOrdersDto, OrderFilterParams>();
        }
    }
}
