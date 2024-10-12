using Microsoft.AspNetCore.Mvc;
using Store.Services.Products.Contracts.Dtos;
using Store.Services.Products.Contracts.Interface;

namespace Store.Api.Products;

[Route("api/products")]
[ApiController]

public class ProductsController:ControllerBase
{
    private readonly ProductService _service;
    
    public ProductsController(ProductService productService)
    {
        _service = productService;
    }

    [HttpPost]
    public async Task<int> Create(AddProductDto dto)
    {
        return await _service.Add(dto);
    }

    [HttpGet("/all")]
    public async Task<IEnumerable<GetProductDto>?> GetAll([FromQuery]string? search)
    {
        return await _service.GetAll(search);
    }

    [HttpPut]
    public async Task Update(UpdateProductDto dto, int productId)
    {
        await _service.Update(dto, productId);
    }
    
    [HttpDelete]
    public async Task Delete(int productId)
    {
        await _service.Delete(productId);
    }

    [HttpGet("/get-count")]
    public async Task<int> GetCount()
    {
        return await _service.GetCount();
    }

    [HttpPatch("/charge-inventory")]
    public async Task IncreaseInventory(int productId, int count)
    {
        await _service.IncreaseInventory(productId, count);
    }
}