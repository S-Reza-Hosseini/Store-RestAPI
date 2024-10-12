namespace Store.Services.Customers.Contracts.Dtos;

public class GetCustomerOrderDto
{
    public required int CustomerId { get; set; }
    public required string CustomerFirstName { get; set; }
    public required string CustomerLastName { get; set; }
    public decimal TotalPrice{ get; set; }
    
}