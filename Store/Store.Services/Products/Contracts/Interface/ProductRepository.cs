using Store.Entities.Products;
using Store.Services.Products.Contracts.Dtos;

namespace Store.Services.Products.Contracts.Interface;

public interface ProductRepository
{
    void Add(Product product);
    Task<IEnumerable<GetProductDto>?> GetAll(string? search);

    Product? Find(int productId);
    int CheckingInventory(int productId);
    Task<bool> IsExistById(int productId);
    void Delete(Product product);
    Task<int> GetCount();
    Task<bool> CheckRepetitive(string dtoTitle);
   
}