using Basket.BLL.DTOs;

namespace Basket.BLL.Services.Interfaces
{
    public interface IBasketService
    {
        Task<BasketDTO> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken);
        Task<BasketDTO> UpdateAsync(Guid customerId, BasketDTO dto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid customerId, CancellationToken cancellationToken);
    }
}
