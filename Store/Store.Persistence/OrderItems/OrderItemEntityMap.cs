using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities.OrderItems;

namespace Store.Persistence.OrderItems;

public class OrderItemEntityMap:IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems").HasKey("Id");
        builder.Property(orderItem => orderItem.Id).IsRequired().UseIdentityColumn();
        builder.Property(orderItem => orderItem.Quantity).IsRequired();
        builder.Property(orderItem => orderItem.OrderId).IsRequired();
        builder.Property(orderItem => orderItem.ProductId).IsRequired();
        builder.Property(orderItem => orderItem.Cost).HasDefaultValue(0).HasColumnType("decimal(18,2)");
    }
}