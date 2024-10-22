using Store.Services.Products.Contracts.Dtos;

namespace Store.Services.Products.Contracts.Interface;

public interface ProductQuery
{
    public Task<List<GetProductDto>?> GetAll(string? search);
}