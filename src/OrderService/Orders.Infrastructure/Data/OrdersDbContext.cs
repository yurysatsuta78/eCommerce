using Microsoft.EntityFrameworkCore;

namespace Orders.Infrastructure.Data
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(OrdersDbContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
