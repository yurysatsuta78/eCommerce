namespace Basket.DAL.Models
{
    public class BasketItemDb
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
