using Microsoft.EntityFrameworkCore;
using Store.Applications.Orders.DoAddOrders;
using Store.Applications.Orders.DoAddOrders.Contracts.interfaces;
using Store.Persistence.Context;
using Store.Persistence.Customers;
using Store.Persistence.OrderItems;
using Store.Persistence.Orders;
using Store.Persistence.Products;
using Store.Services.Customers;
using Store.Services.Customers.Contracts.Interface;
using Store.Services.OrderItems.Contracts.Interface;
using Store.Services.Orders;
using Store.Services.Orders.Contracts.Interface;
using Store.Services.Products;
using Store.Services.Products.Contracts.Interface;
using Store.Services.UnitOfWorks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDbContext<StoreDataContext>(
        option => option.UseSqlServer(
            builder.Configuration
                .GetConnectionString(
                    "DefaultConnection")));

builder.Services.AddScoped<CustomerRepository, EFCustomerRepository>();
builder.Services.AddScoped<ProductRepository, EFProductRepository>();
builder.Services.AddScoped<OrderRepository, EFOrderRepository>();
builder.Services.AddScoped<OrderItemRepository, EFOrderItemRepository>();
builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();

builder.Services.AddScoped<CustomerService, CustomerAppService>();
builder.Services.AddScoped<ProductService, ProductAppService>();
builder.Services.AddScoped<OrderService, OrderAppService>();
builder.Services.AddScoped<DoAddOrder, DoCommandOrder>();

builder.Services.AddScoped<CustomerQuery, EFCustomerQuery>();
builder.Services.AddScoped<OrderQuery, EFOrderQuery>();
builder.Services.AddScoped<ProductQuery, EFProductQuery>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllers();
}

app.UseHttpsRedirection();



app.Run();

