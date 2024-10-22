using FluentAssertions;
using Store.Entities.Customers;
using Store.Entities.OrderItems;
using Store.Entities.Orders;
using Store.Entities.Products;
using Store.Persistence.Customers;
using Store.Services.Customers.Contracts.Dtos;
using Store.Services.Customers.Contracts.Interface;
using Store.Services.Tests.Infrastructure.DataBaseConfig.Integration;

namespace Store.Services.Tests.Customers;

public class CustomerQueryTests:BusinessIntegrationTest
{
    private readonly CustomerQuery _sut;

    public CustomerQueryTests()
    {
        _sut = new EFCustomerQuery(Context);
    }

    [Fact]
    public async Task GetAll()
    {
        var customer = new Customer()
        {
            FirstName = "ali",
            LastName = "alizadeh",
            PhoneNumber = "0917454646"
        };
        
        Save(customer);
        
        var customer2 = new Customer()
        {
            FirstName = "reza",
            LastName = "mohammadZadeh",
            PhoneNumber = "09174546467"
        };
        
        Save(customer2);


        var actual = await _sut.GetAll();

        actual.Count.Should().Be(2);

        actual.First().Should().BeEquivalentTo(new GetCustomerDto()
        {
        Id = customer.Id,
        FirstName = customer.FirstName,
        LastName = customer.LastName,
        PhoneNumber = customer.PhoneNumber
        });
        
    }

    [Fact]
    public async Task Get_customer_orders()
    {
        var customer = CreateCustomer("ali", "haghShenas", "02145678");
        Save(customer);

        var product = new Product()
        {
        Title = "Glass",
        Price = 1000,
        Inventory = 0
        };
        Save(product);
        
        var order = new Order()
        {
        CustomerId = customer.Id,
        OrderItems = new List<OrderItem>()
        {
            new OrderItem()
            {
                ProductId = product.Id,
                Quantity = 2
           }
        }
        };
        
        Save(order);

        var result = await _sut.GetCustomerOrders(customer.Id);

        result.Should().NotBeNull();
        result.Count.Should().Be(1);
        result.First().Should().BeEquivalentTo(new GetCustomerOrderDto()
        {
            CustomerId = customer.Id,
            CustomerFirstName = customer.FirstName,
            CustomerLastName = customer.LastName,
            TotalPrice = order.TotalPrice
        });

    }



    private Customer CreateCustomer(string firstName, string lastName, string phoneNumber)
    {
        return new Customer()
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber
        };
    }
}