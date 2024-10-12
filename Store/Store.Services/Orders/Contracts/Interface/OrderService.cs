using Store.Services.Orders.Contracts.Dtos;

namespace Store.Services.Orders.Contracts.Interface;

public interface OrderService
{
    Task<int> Add(AddOrderDto dto);
    Task<IEnumerable<GetOrderDto>?> GetAll();
}