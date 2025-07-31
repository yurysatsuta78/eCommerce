using Basket.BLL.Dto;

namespace Basket.BLL.Services.Interfaces
{
    public interface IBasketService
    {
        Task<CustomerBasketDto> GetByCustomerIdAsync(Guid customerId);
        Task<CustomerBasketDto> UpdateAsync(Guid customerId, CustomerBasketDto dto);
        Task DeleteAsync(Guid customerId);
    }
}
