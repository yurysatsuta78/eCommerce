using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Models;

namespace Order.Infrastructure.Configurations
{
    public class CustomerOrderConfig : IEntityTypeConfiguration<CustomerOrder>
    {
        public void Configure(EntityTypeBuilder<CustomerOrder> builder) 
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
            builder.Metadata.FindNavigation(nameof(CustomerOrder.OrderItems))?.SetField("_orderItems");

            builder.Ignore(co => co.TotalPrice);
        }
    }
}
