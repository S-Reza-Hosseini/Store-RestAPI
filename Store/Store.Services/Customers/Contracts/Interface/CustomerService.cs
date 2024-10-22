using Store.Services.Customers.Contracts.Dtos;

namespace Store.Services.Customers.Contracts.Interface;

public interface CustomerService
{
    Task<int> Add(AddCustomerDto dto);
    Task Delete(int customerId);
}