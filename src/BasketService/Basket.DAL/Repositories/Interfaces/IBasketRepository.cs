using Basket.DAL.Models;

namespace Basket.DAL.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        Task<BasketDb?> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken);
        Task UpdateAsync(BasketDb basket, CancellationToken cancellationToken);
        Task DeleteAsync(Guid customerId, CancellationToken cancellationToken);
    }
}