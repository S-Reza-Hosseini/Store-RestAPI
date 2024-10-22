using Store.Entities.OrderItems;

namespace Store.Entities.Orders;

public class Order
{
    public int Id { get; set; }
    public required int CustomerId { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public decimal TotalPrice { get; set; }

    public IEnumerable<OrderItem> OrderItems { get; set; } = [];
}