namespace Basket.DAL.Models
{
    public class BasketItemDb
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
