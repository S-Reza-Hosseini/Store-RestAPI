using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Store.Entities.Customers;
using Store.Persistence.Context;
using Store.Persistence.Customers;
using Store.Services.Customers;
using Store.Services.Customers.Contracts.Dtos;
using Store.Services.Customers.Contracts.Interface;
using Store.Services.Tests.Infrastructure.DataBaseConfig.Integration;
using Store.Services.UnitOfWorks;

namespace Store.Services.Tests.Customers;

public class CustomerServiceTests:BusinessIntegrationTest
{
    private readonly CustomerService _sut;

    public CustomerServiceTests()
    {
        var unitOfWork = new EFUnitOfWork(Context);
        var repository = new EFCustomerRepository(Context);
        _sut = new CustomerAppService(repository,unitOfWork);
    }

    [Fact]
    public async Task Create_customer_properly()
    {
        var customer = new AddCustomerDto()
        {
            FirstName = "dummy",
            LastName = "d",
            PhoneNumber = "01864946"
        };
        
        var result = await _sut.Add(customer);

        
        var actual = await Context.Customers.SingleAsync();

        actual!.FirstName.Should().Contain(customer.FirstName);
        actual.LastName.Should().Contain(customer.LastName);
        actual.PhoneNumber.Should().Contain(customer.PhoneNumber);
        
    }


    [Fact]
    public async Task Delete()
    {
        var customer = new Customer()
        {
        FirstName = "ali",
        LastName = "h",
        PhoneNumber = "049649779"
        };
        
        Save(customer);

        await _sut.Delete(customer.Id);

        var actual = await ReadContext.Customers.AnyAsync(_ => _.Id == customer.Id);
        actual.Should().BeFalse();

        ReadContext.Customers.Count().Should().Be(0);
    }
    
    
    
    
}