using Store.Services.Products.Contracts.Dtos;

namespace Store.Services.Products.Contracts.Interface;

public interface ProductService
{
    Task<int> Add(AddProductDto dto);
    Task Update(UpdateProductDto dto, int productId);
    Task Delete(int productId);
    Task<int> GetCount();
    Task IncreaseInventory(int productId, int count);
}