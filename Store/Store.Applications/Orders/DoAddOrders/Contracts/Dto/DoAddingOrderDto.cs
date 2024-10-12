using System.ComponentModel.DataAnnotations;

namespace Store.Applications.Orders.DoAddOrders.Contracts.Dto;

public class DoAddingOrderDto
{
   
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    
    public class Item
    {
        public required int ProductId { get; set; }
        public required int Quantity { get; set; }
    }

    public required IEnumerable<Item> Items { get; set; } = [];
}