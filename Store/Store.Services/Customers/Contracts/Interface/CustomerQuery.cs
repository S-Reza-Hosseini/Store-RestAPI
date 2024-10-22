using Store.Services.Customers.Contracts.Dtos;

namespace Store.Services.Customers.Contracts.Interface;

public interface CustomerQuery
{
    public Task<List<GetCustomerDto>> GetAll();

    public Task<List<GetCustomerOrderDto>> GetCustomerOrders(int id);
}