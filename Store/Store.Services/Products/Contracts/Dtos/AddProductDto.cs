using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Store.Services.Products.Contracts.Dtos;

public class AddProductDto
{
    public required string Title { get; set; }
    
    public string? Description { get; set; }
    public required decimal Price { get; set; }
    public int Inventory { get; set; }
}