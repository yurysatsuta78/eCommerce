using AutoMapper;
using Basket.BLL.Dto;
using Basket.DAL.Models;

namespace Basket.BLL.MappingProfiles
{
    public class BasketItemProfile : Profile
    {
        public BasketItemProfile() 
        {
            CreateMap<BasketItemDto, BasketItemDb>().ReverseMap();
        }
    }
}
