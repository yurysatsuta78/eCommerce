namespace Basket.DAL.Models
{
    public class BasketDb
    {
        public Guid CustomerId { get; set; }
        public List<BasketItemDb> BasketItems { get; set; } = new();
    }
}
