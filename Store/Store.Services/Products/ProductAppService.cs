using Store.Entities.Products;
using Store.Services.Customers.Contracts.Interface;
using Store.Services.Products.Contracts.Dtos;
using Store.Services.Products.Contracts.Interface;
using Store.Services.UnitOfWorks;

namespace Store.Services.Products;

public class ProductAppService(ProductRepository repository, UnitOfWork unitOfWork):ProductService
{
    public async Task<int> Add(AddProductDto dto)
    {
        var product = new Product()
        {
        Title = dto.Title,
        Description = dto.Description,
        Price = dto.Price,
        Inventory = dto.Inventory
        };

        if (!await repository.CheckRepetitive(dto.Title))
        {
            throw new Exception("this title is repetitive!");
        }
        
        repository.Add(product);

        await unitOfWork.Save();

        return product.Id;
    }
    
    public async Task Update(UpdateProductDto dto, int productId)
    {
        if (!await repository.IsExistById(productId))
        {
            throw new Exception($"product with id {productId} not found!");
        }
        
        var product = repository.Find(productId);

        product!.Title = dto.Title;
        product.Description = dto.Description;
        product.Price = dto.Price;

        await unitOfWork.Save();

    }

    public async Task Delete(int productId)
    {
        if (!await repository.IsExistById(productId))
        {
            throw new Exception($"product with id {productId} not found!");
        }
        
        var product = repository.Find(productId);

        repository.Delete(product!);

        await unitOfWork.Save();
    }

    public async Task<int> GetCount()
    {
        return await repository.GetCount();
    }

    public async Task IncreaseInventory(int productId, int count)
    {
        if (!await repository.IsExistById(productId))
        {
            throw new Exception($"product with id {productId} is not found!");
        }

        var product = repository.Find(productId);

        product!.Inventory += count;

        await unitOfWork.Save();
    }
}