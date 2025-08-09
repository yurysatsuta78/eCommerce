using AutoMapper;
using Basket.BLL.DTOs;
using Basket.DAL.Models;

namespace Basket.BLL.MappingProfiles
{
    public class BasketItemProfile : Profile
    {
        public BasketItemProfile() 
        {
            CreateMap<BasketItemDTO, BasketItemDb>().ReverseMap();
        }
    }
}
