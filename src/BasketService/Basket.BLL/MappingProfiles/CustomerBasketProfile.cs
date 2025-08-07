using AutoMapper;
using Basket.BLL.Dto;
using Basket.DAL.Models;

namespace Basket.BLL.MappingProfiles
{
    public class CustomerBasketProfile : Profile
    {
        public CustomerBasketProfile() 
        {
            CreateMap<CustomerBasketDto, CustomerBasketDb>().ReverseMap();
        }
    }
}
