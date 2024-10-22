using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Store.Entities.Products;
using Store.Persistence.Context;
using Store.Services.Customers.Contracts.Interface;
using Store.Services.Products.Contracts.Dtos;
using Store.Services.Products.Contracts.Interface;

namespace Store.Persistence.Products;

public class EFProductRepository(StoreDataContext context):ProductRepository
{
    public void Add(Product product)
    {
        context.Products.Add(product);
    }
    
    public Product? Find(int productId)
    {
        return context.Products.FirstOrDefault(_ => _.Id == productId);
    }

    public int CheckingInventory(int productId)
    {
        return context.Products.FirstOrDefault(_ => _.Id == productId).Inventory;
    }

    public async Task<bool> IsExistById(int productId)
    {
        return await context.Products.AnyAsync(product => product.Id == productId);
    }
    
    public void Delete(Product product)
    {
         context .Products.Remove(product);
    }
    
    public async Task<int> GetCount()
    {
        return await context.Products.CountAsync();
    }
    
    public async Task<bool> CheckRepetitive(string dtoTitle)
    {
        return await context.Products.AnyAsync(product => product.Title.Trim() == dtoTitle.Trim());
    }

    
}