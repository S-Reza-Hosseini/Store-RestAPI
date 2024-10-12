using Store.Entities.OrderItems;
using Store.Services.Orders.Contracts.Dtos;

namespace Store.Services.OrderItems.Contracts.Interface;

public interface OrderItemRepository
{
    Task Add(IEnumerable<OrderItem> orderItems);
}