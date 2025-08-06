using AutoMapper;
using Orders.Application.Dto.Request;
using Orders.Application.Dto.Response;
using Orders.Domain.Models;

namespace Orders.Infrastructure.MappingProfiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile() 
        {
            CreateMap<CreateOrderItemDto, OrderItem>()
                .ConvertUsing(dto => 
                    OrderItem.Create(dto.ItemId, dto.Name, dto.Quantity, dto.Price));

            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
