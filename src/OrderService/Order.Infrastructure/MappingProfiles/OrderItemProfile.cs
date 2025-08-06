using AutoMapper;
using Order.Application.Dto.Request;
using Order.Application.Dto.Response;
using Order.Domain.Models;

namespace Order.Infrastructure.MappingProfiles
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
