using Microsoft.AspNetCore.Mvc;
using Store.Services.Customers.Contracts.Dtos;
using Store.Services.Customers.Contracts.Interface;

namespace Store.Api.Customers;

[Route("api/customers")]
[ApiController]

public class CustomersController(CustomerService customerService,
    CustomerQuery customerQuery):ControllerBase
{
    
    [HttpPost]
    public async Task<int> Create(AddCustomerDto dto)
    {
        return await customerService.Add(dto);
    }

    [HttpGet]
    public async Task<List<GetCustomerDto>?> GetAll()
    {
        return await customerQuery.GetAll();
    }

    [HttpGet("/get-{id}-orders")]
    public async Task<IEnumerable<GetCustomerOrderDto>> GetCustomerOrders([FromRoute] int id)
    {
        return await customerQuery.GetCustomerOrders(id);
    }

    [HttpDelete]
    public async Task Delete(int customerId)
    {
        await customerService.Delete(customerId);
    }
    
    
}