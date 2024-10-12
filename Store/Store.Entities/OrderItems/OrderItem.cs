using Store.Entities.Orders;

namespace Store.Entities.OrderItems;

public class OrderItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int Quantity { get; set; }
    public decimal Cost { get; set; }

    
}