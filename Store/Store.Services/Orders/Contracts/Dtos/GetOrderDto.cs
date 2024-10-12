namespace Store.Services.Orders.Contracts.Dtos;

public class GetOrderDto
{
    public required int Id { get; set; }
    public  decimal TotalPrice { get; set; }
    public required IEnumerable<string> ProductNames { get; set; }
}