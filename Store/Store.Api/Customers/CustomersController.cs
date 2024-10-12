using Microsoft.AspNetCore.Mvc;
using Store.Services.Customers.Contracts.Dtos;
using Store.Services.Customers.Contracts.Interface;

namespace Store.Api.Customers;

[Route("api/customers")]
[ApiController]

public class CustomersController:ControllerBase
{
    private readonly CustomerService _service;

    public CustomersController(CustomerService customerService)
    {
        _service = customerService;
    }

    [HttpPost]
    public async Task<int> Create(AddCustomerDto dto)
    {
        return await _service.Add(dto);
    }

    [HttpGet]
    public async Task<List<GetCustomerDto>?> GetAll()
    {
        return await _service.GetAll();
    }

    [HttpGet("/get-{id}-orders")]
    public async Task<IEnumerable<GetCustomerOrderDto>?> GetCustomerOrders([FromRoute] int id)
    {
        return await _service.GetAllCustomerOrders(id);
    }

    [HttpDelete]
    public async Task Delete(int customerId)
    {
        await _service.Delete(customerId);
    }
    
    
}