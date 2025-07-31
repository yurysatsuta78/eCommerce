namespace Basket.DAL.Models
{
    public class CustomerBasketDb
    {
        public Guid CustomerId { get; set; }
        public List<BasketItemDb> Items { get; set; } = new();
    }
}
