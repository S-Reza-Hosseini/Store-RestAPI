using Store.Services.Customers.Contracts.Dtos;

namespace Store.Services.Customers.Contracts.Interface;

public interface CustomerService
{
    Task<int> Add(AddCustomerDto dto);
    Task<List<GetCustomerDto>?> GetAll();
    Task<IEnumerable<GetCustomerOrderDto>?> GetAllCustomerOrders(int id);
    Task Delete(int customerId);
}