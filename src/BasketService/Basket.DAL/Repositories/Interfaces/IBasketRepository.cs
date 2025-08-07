using Basket.DAL.Models;

namespace Basket.DAL.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasketDb?> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken);
        Task UpdateAsync(CustomerBasketDb basket, CancellationToken cancellationToken);
        Task DeleteAsync(Guid customerId, CancellationToken cancellationToken);
    }
}