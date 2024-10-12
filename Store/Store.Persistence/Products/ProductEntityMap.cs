using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities.Products;

namespace Store.Persistence.Products;

public class ProductEntityMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey("Id");
        builder.Property(product => product.Id).IsRequired().UseIdentityColumn();
        builder.Property(product => product.Title).IsRequired().HasMaxLength(100);
        builder.Property(product => product.Description).IsRequired(false).HasMaxLength(500);
        builder.Property(product => product.Price).HasDefaultValue(0).HasColumnType("decimal(18,2)");
        builder.Property(product => product.Inventory).HasDefaultValue(0);
    }
}