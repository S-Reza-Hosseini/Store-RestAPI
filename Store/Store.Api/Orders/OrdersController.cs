using Microsoft.AspNetCore.Mvc;
using Store.Applications.Orders.DoAddOrders.Contracts.Dto;
using Store.Applications.Orders.DoAddOrders.Contracts.interfaces;
using Store.Services.Orders.Contracts.Dtos;
using Store.Services.Orders.Contracts.Interface;

namespace Store.Api.Orders;

[Route("api/orders")]
[ApiController]

public class OrdersController:ControllerBase
{
    private readonly OrderService _service;
    private readonly DoAddOrder _handler;
    
    public OrdersController(OrderService orderService, DoAddOrder addOrder)
    {
        _service = orderService;
        _handler = addOrder;

    }

    [HttpPost]
    public async Task<int> Create(AddOrderDto dto)
    {
        return await _service.Add(dto);
    }

    [HttpGet("/get-all")]
    public async Task<IEnumerable<GetOrderDto>?> GetAll()
    {
        return await _service.GetAll();
    }

    [HttpPost("/order-and-customer")]
    public async Task AddOrderAndCustomer(DoAddingOrderDto dto)
    {
        await _handler.Add(dto);
    }
}