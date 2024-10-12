namespace Store.Services.Products.Contracts.Dtos;

public class UpdateProductDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
}