using Microsoft.AspNetCore.Mvc;
using Store.Services.Products.Contracts.Dtos;
using Store.Services.Products.Contracts.Interface;

namespace Store.Api.Products;

[Route("api/products")]
[ApiController]

public class ProductsController(ProductService productService, ProductQuery productQuery):ControllerBase
{
   
    [HttpPost]
    public async Task<int> Create(AddProductDto dto)
    {
        return await productService.Add(dto);
    }

    [HttpGet("/all")]
    public async Task<List<GetProductDto>?> GetAll([FromQuery]string? search)
    {
        return await productQuery.GetAll(search);
    }

    [HttpPut]
    public async Task Update(UpdateProductDto dto, int productId)
    {
        await productService.Update(dto, productId);
    }
    
    [HttpDelete]
    public async Task Delete(int productId)
    {
        await productService.Delete(productId);
    }

    [HttpGet("/get-count")]
    public async Task<int> GetCount()
    {
        return await productService.GetCount();
    }

    [HttpPatch("/charge-inventory")]
    public async Task IncreaseInventory(int productId, int count)
    {
        await productService.IncreaseInventory(productId, count);
    }
}