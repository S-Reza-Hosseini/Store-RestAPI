using Store.Entities.Orders;
using Store.Services.Orders.Contracts.Dtos;

namespace Store.Services.Orders.Contracts.Interface;

public interface OrderRepository
{
    Task Add(Order order);
 
}