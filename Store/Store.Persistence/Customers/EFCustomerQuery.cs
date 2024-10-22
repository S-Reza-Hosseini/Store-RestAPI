using Microsoft.EntityFrameworkCore;
using Store.Persistence.Context;
using Store.Services.Customers.Contracts.Dtos;
using Store.Services.Customers.Contracts.Interface;

namespace Store.Persistence.Customers;

public class EFCustomerQuery(StoreDataContext context):CustomerQuery
{
    
    public async Task<List<GetCustomerDto>> GetAll()
    {
        return await context.Customers.Select(_ => new GetCustomerDto()
        {
            Id = _.Id,
            FirstName = _.FirstName,
            LastName = _.LastName,
            PhoneNumber = _.PhoneNumber
        }).ToListAsync();
    }

    public async Task<List<GetCustomerOrderDto>> GetCustomerOrders(int id)
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

        ).ToListAsync();
    }

}