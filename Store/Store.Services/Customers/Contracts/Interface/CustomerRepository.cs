using Store.Entities.Customers;
using Store.Services.Customers.Contracts.Dtos;

namespace Store.Services.Customers.Contracts.Interface;

public interface CustomerRepository
{
    Task Add(Customer customer);
    Task<List<GetCustomerDto>?> GetAll();
    Task<IEnumerable<GetCustomerOrderDto>?> GetCustomerOrders(int id);
    Task<bool> IsExistById(int customerId);
    Task<Customer?> Find(int customerId);
    void Delete(Customer? customer);
}