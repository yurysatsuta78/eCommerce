using AutoMapper;
using Payment.BLL.DTOs.ReceiptDTOs;
using Payment.DAL.QueryParams;

namespace Payment.BLL.MappingProfiles.FilterProfiles
{
    public class ReceiptFilterProfile : Profile
    {
        public ReceiptFilterProfile() 
        {
            CreateMap<GetFilteredReceiptsDTO, ReceiptQueryParams>();
        }
    }
}
