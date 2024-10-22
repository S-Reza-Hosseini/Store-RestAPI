using Microsoft.EntityFrameworkCore;
using Store.Persistence.Context;
using Store.Services.Products.Contracts.Dtos;
using Store.Services.Products.Contracts.Interface;

namespace Store.Persistence.Products;

public class EFProductQuery(StoreDataContext context):ProductQuery
{
    public async Task<List<GetProductDto>?> GetAll(string? search)
    {
        return await context.Products.Select(_ => new GetProductDto()
        {
            Id = _.Id,
            Title = _.Title,
            Description = _.Description,
            Price = _.Price
        }).ToListAsync();
    }

}