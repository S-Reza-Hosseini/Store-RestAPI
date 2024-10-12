namespace Store.Services.Products.Contracts.Dtos;

public class GetProductDto
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required decimal Price { get; set; }
}