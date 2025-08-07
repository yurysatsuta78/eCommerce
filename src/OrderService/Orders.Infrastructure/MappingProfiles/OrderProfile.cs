using AutoMapper;
using Orders.Application.Dto.Request;
using Orders.Application.Dto.Response;
using Orders.Domain.Models;

namespace Orders.Infrastructure.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        {
            CreateMap<CreateOrderDto, Order>()
                .ConvertUsing((dto, _, context) => 
                    Order.Create(
                        Guid.NewGuid(),
                        dto.CustomerId,
                        context.Mapper.Map<List<OrderItem>>(dto.OrderItems)
                    )
            );

            CreateMap<Order, OrderDto>();
        }
    }
}
