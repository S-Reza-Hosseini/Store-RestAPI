using Store.Services.Orders.Contracts.Dtos;

namespace Store.Services.Orders.Contracts.Interface;

public interface OrderQuery
{
    public Task<List<GetOrderDto>> GetAll();
}