using Microsoft.AspNetCore.Mvc;
using Store.Applications.Orders.DoAddOrders.Contracts.Dto;
using Store.Applications.Orders.DoAddOrders.Contracts.interfaces;
using Store.Services.Orders.Contracts.Dtos;
using Store.Services.Orders.Contracts.Interface;

namespace Store.Api.Orders;

[Route("api/orders")]
[ApiController]

public class OrdersController(OrderService orderService,DoAddOrder addOrderHandler , OrderQuery orderQuery ):ControllerBase
{
   
    [HttpPost]
    public async Task<int> Create(AddOrderDto dto)
    {
        return await orderService.Add(dto);
    }

    [HttpGet("/get-all")]
    public async Task<List<GetOrderDto>?> GetAll()
    {
        return await orderQuery.GetAll();
    }

    [HttpPost("/order-and-customer")]
    public async Task AddOrderAndCustomer(DoAddingOrderDto dto)
    {
        await addOrderHandler.Add(dto);
    }
}