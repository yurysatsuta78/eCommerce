using Basket.DAL.Models;

namespace Basket.DAL.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasketDb?> GetByCustomerIdAsync(Guid customerId);
        Task<bool> UpdateAsync(CustomerBasketDb basket);
        Task<bool> DeleteAsync(Guid customerId);
    }
}