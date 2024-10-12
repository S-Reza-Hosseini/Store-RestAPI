using Store.Entities.OrderItems;
using Store.Persistence.Context;
using Store.Services.Customers.Contracts.Interface;
using Store.Services.OrderItems.Contracts.Interface;
using Store.Services.Orders.Contracts.Dtos;

namespace Store.Persistence.OrderItems;

public class EFOrderItemRepository(StoreDataContext context):OrderItemRepository
{
    public async Task Add(IEnumerable<OrderItem> orderItems)
    {
        await context.AddRangeAsync(orderItems);
    }
}