using Store.Entities.Customers;
using Store.Services.Customers.Contracts.Dtos;
using Store.Services.Customers.Contracts.Interface;
using Store.Services.UnitOfWorks;

namespace Store.Services.Customers;

public class CustomerAppService(CustomerRepository repository, UnitOfWork unitOfWork):CustomerService
{
    public async Task<int> Add(AddCustomerDto dto)
    {
        var customer = new Customer()
        {
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        PhoneNumber = dto.PhoneNumber
        };

        await repository.Add(customer);

        await unitOfWork.Save();
        
        return customer.Id;
    }
    
    public async Task Delete(int customerId)
    {
        if (!await repository.IsExistById(customerId))
        {
            throw new Exception($"customer with id {customerId} not found!");
        }

        var customer = await repository.Find(customerId);

        repository.Delete(customer);

        await unitOfWork.Save();
    }
}