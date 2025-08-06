using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain.Models;

namespace Orders.Infrastructure.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder) 
        {
            builder.HasKey(co => co.Id);

            builder.ToTable("CustomerOrders");

            builder.Property(co => co.CustomerId)
                .IsRequired();

            builder.Property(co => co.Status)
                .HasConversion<string>()
                .IsRequired();

            builder.HasMany(co => co.OrderItems)
                .WithOne()
                .HasForeignKey("CustomerOrderId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Metadata.FindNavigation(nameof(Order.OrderItems))?.SetField("_orderItems");

            builder.Ignore(co => co.TotalPrice);
        }
    }
}
