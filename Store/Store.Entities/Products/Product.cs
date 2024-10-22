namespace Store.Entities.Products;

public class Product
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public int Inventory { get; set; }
}