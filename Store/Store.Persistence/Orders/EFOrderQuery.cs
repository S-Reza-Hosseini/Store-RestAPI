using Microsoft.EntityFrameworkCore;
using Store.Persistence.Context;
using Store.Services.Orders.Contracts.Dtos;
using Store.Services.Orders.Contracts.Interface;

namespace Store.Persistence.Orders;

public class EFOrderQuery(StoreDataContext context):OrderQuery
{
    public async Task<List<GetOrderDto>> GetAll()
    {
        return await context.Orders.Select(_ => new GetOrderDto()
        {
            Id = _.Id,
            TotalPrice = _.TotalPrice,
            ProductNames = _.OrderItems
                .Join(context.Products, orderItem => orderItem.ProductId, product => product.Id, 
                    (orderItem, product) => product.Title)
                .ToList()
            
        }).ToListAsync();
    }
}