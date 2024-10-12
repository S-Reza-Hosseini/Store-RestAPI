namespace Store.Services.Orders.Contracts.Dtos;

public class AddOrderDto
{
    public required int CustomerId { get; set; }
    
    public class Detail
    {
        public required int ProductId { get; set; }
        public required int Quantity { get; set; }
    }

    public required IEnumerable<Detail> Details { get; set; }
}