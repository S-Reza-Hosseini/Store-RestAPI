using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities.Customers;

namespace Store.Persistence.Customers;

public class CustomerEntityMap:IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey("Id");
        builder.Property(customer => customer.Id).UseIdentityColumn().IsRequired();
        builder.Property(customer => customer.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(customer => customer.LastName).HasMaxLength(100).IsRequired();
        builder.Property(customer => customer.PhoneNumber).HasMaxLength(11).IsRequired();
    }
}