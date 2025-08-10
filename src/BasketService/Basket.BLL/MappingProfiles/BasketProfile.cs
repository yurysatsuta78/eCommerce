using AutoMapper;
using Basket.BLL.DTOs;
using Basket.DAL.Models;

namespace Basket.BLL.MappingProfiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile() 
        {
            CreateMap<BasketDTO, BasketDb>().ReverseMap();
        }
    }
}
