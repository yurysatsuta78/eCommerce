using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain.Models;

namespace Orders.Infrastructure.Configurations
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder) 
        {
            builder.Property<Guid>("OrderId");

            builder.HasKey("OrderId", nameof(OrderItem.ItemId));

            builder.ToTable("OrderItems", tableBuilder =>
            {
                tableBuilder.HasCheckConstraint("CK_OrderItems_Quantity_Positive", "\"Quantity\" > 0");
                tableBuilder.HasCheckConstraint("CK_OrderItems_Price_Positive", "\"Price\" > 0");
            });

            builder.Property(oi => oi.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(oi => oi.Quantity)
                .IsRequired();

            builder.Property(oi => oi.Price)
                .IsRequired();

            builder.Ignore(oi => oi.TotalPrice);
        }
    }
}
