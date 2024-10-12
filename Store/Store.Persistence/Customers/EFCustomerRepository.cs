using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Store.Entities.Customers;
using Store.Persistence.Context;
using Store.Services.Customers.Contracts.Dtos;
using Store.Services.Customers.Contracts.Interface;

namespace Store.Persistence.Customers;

public class EFCustomerRepository(StoreDataContext context):CustomerRepository
{
    public async Task Add(Customer customer)
    {
        await context.Customers.AddAsync(customer);
    }

    public Task<List<GetCustomerDto>?> GetAll()
    {
        return context.Customers.Select(_ => new GetCustomerDto()
        {
            Id = _.Id,
            FirstName = _.FirstName,
            LastName = _.LastName,
            PhoneNumber = _.PhoneNumber
        }).ToListAsync();
    }

    public async Task<IEnumerable<GetCustomerOrderDto>?> GetCustomerOrders(int id)
    {
        return await (
            from customer in context.Customers
            join order in context.Orders on customer.Id equals order.CustomerId
            select new GetCustomerOrderDto()
            {
                CustomerId = customer.Id,
                CustomerFirstName = customer.FirstName,
                CustomerLastName = customer.LastName,
                TotalPrice = order.TotalPrice
            }

        ).ToArrayAsync();
    }

    public async Task<bool> IsExistById(int customerId)
    {
        return await context.Customers.AnyAsync(customer => customer.Id == customerId);
    }

    public async Task<Customer?> Find(int customerId)
    {
        return await context.Customers.FirstOrDefaultAsync(customer => customer.Id == customerId);
    }

    public void Delete(Customer? customer)
    {
        context.Customers.Remove(customer!);
    }
}