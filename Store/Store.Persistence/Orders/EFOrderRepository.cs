using Microsoft.EntityFrameworkCore;
using Store.Entities.Orders;
using Store.Persistence.Context;
using Store.Services.Orders.Contracts.Dtos;
using Store.Services.Orders.Contracts.Interface;

namespace Store.Persistence.Orders;

public class EFOrderRepository(StoreDataContext context):OrderRepository
{
    public async Task Add(Order order)
    {
        await context.Orders.AddAsync(order);
    }

    public async Task<IEnumerable<GetOrderDto>?> GetAll()
    {
        return await context.Orders.Select(_ => new GetOrderDto()
        {
        Id = _.Id,
        TotalPrice = _.TotalPrice,
        ProductNames = _.OrderItems
            .Join(context.Products, orderItem => orderItem.ProductId, product => product.Id, 
                (orderItem, product) => product.Title)
            .ToList()
            
        }).ToArrayAsync();
    }
}