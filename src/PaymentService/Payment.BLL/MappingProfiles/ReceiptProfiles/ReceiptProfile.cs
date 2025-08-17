using AutoMapper;
using Payment.BLL.DTOs.ReceiptDTOs;
using Payment.DAL.Models;

namespace Payment.BLL.MappingProfiles.ReceiptProfiles
{
    public class ReceiptProfile : Profile
    {
        public ReceiptProfile() 
        {
            CreateMap<ReceiptDb, ReceiptDTO>();
        }
    }
}
