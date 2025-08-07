using Basket.BLL.Dto;

namespace Basket.BLL.Services.Interfaces
{
    public interface IBasketService
    {
        Task<CustomerBasketDto> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken);
        Task<CustomerBasketDto> UpdateAsync(Guid customerId, CustomerBasketDto dto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid customerId, CancellationToken cancellationToken);
    }
}
