using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities.Orders;

namespace Store.Persistence.Orders;

public class OrderEntityMap:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders").HasKey("Id");
        builder.Property(order => order.Id).IsRequired().UseIdentityColumn();
        builder.Property(order => order.CustomerId).IsRequired();
        builder.Property(order => order.DateTime).IsRequired();
        builder.Property(product => product.TotalPrice).HasDefaultValue(0).HasColumnType("decimal(18,2)");
        builder.HasMany(order => order.OrderItems)
            .WithOne(orderItem => orderItem.Order)
            .HasForeignKey(orderItem => orderItem.OrderId);

    }
}