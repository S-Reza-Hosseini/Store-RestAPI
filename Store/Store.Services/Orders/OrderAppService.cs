using System.Security.Cryptography;
using Store.Entities.OrderItems;
using Store.Entities.Orders;
using Store.Services.Customers.Contracts.Interface;
using Store.Services.OrderItems.Contracts.Interface;
using Store.Services.Orders.Contracts.Dtos;
using Store.Services.Orders.Contracts.Interface;
using Store.Services.Products.Contracts.Interface;
using Store.Services.UnitOfWorks;

namespace Store.Services.Orders;

public class OrderAppService(
    OrderRepository repository,
    OrderItemRepository orderItemRepository,
    ProductRepository productRepository,
    CustomerRepository customerRepository,
    UnitOfWork unitOfWork):OrderService
{
    public async Task<int> Add(AddOrderDto dto)
    {
        if (!await customerRepository.IsExistById(dto.CustomerId))
        {
            throw new Exception($"customer with id {dto.CustomerId} was not found!");
        }
        var order = new Order()
        {
            CustomerId = dto.CustomerId,
            DateTime = DateTime.Now,
        };
        
        order.OrderItems = dto.Details.Select(detail => 
        {
            
            if (detail.Quantity > productRepository.CheckingInventory(detail.ProductId)) 
            {
                throw new Exception($"Insufficient inventory for product ID:" +
                                    $" {detail.ProductId}. Requested: {detail.Quantity}," +
                                    $" Available: {productRepository.CheckingInventory(detail.ProductId)}"); 
            }
            
            return new OrderItem()
            {
                ProductId = detail.ProductId,
                Quantity = detail.Quantity,
                Cost = productRepository.Find(detail.ProductId)!.Price * detail.Quantity, 
            };
        }).ToList();
        
        CalculatePrice(order);
        
        await repository.Add(order); 
        
        await unitOfWork.Save();
        
        return order.Id;
    }
    

    public void CalculatePrice(Order order)
    {
        order.TotalPrice = order.OrderItems.Sum(orderItem => orderItem.Cost);
    }
}