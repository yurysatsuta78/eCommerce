using AutoMapper;
using Order.Application.Dto.Request;
using Order.Domain.QueryParams;

namespace Order.Infrastructure.MappingProfiles.FilterProfiles
{
    public class CustomerOrderFilterProfile : Profile
    {
        public CustomerOrderFilterProfile() 
        {
            CreateMap<GetFilteredCustomerOrdersDto, CustomerOrderFilterParams>();
        }
    }
}
