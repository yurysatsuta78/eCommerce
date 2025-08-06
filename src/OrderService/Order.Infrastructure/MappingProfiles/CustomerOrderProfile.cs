using AutoMapper;
using Order.Application.Dto.Request;
using Order.Application.Dto.Response;
using Order.Domain.Models;

namespace Order.Infrastructure.MappingProfiles
{
    public class CustomerOrderProfile : Profile
    {
        public CustomerOrderProfile() 
        {
            CreateMap<CreateCustomerOrderDto, CustomerOrder>()
                .ConvertUsing((dto, _, context) => 
                    CustomerOrder.Create(
                        Guid.NewGuid(),
                        dto.CustomerId,
                        context.Mapper.Map<List<OrderItem>>(dto.OrderItems)
                    )
            );

            CreateMap<CustomerOrder, CustomerOrderDto>();
        }
    }
}
