using Microsoft.EntityFrameworkCore;
using Store.Entities.Customers;
using Store.Entities.OrderItems;
using Store.Entities.Orders;
using Store.Entities.Products;

namespace Store.Persistence.Context;

public class StoreDataContext:DbContext
{
    public StoreDataContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Customer).Assembly);
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}