using Store.Applications.Orders.DoAddOrders.Contracts.Dto;
using Store.Applications.Orders.DoAddOrders.Contracts.interfaces;
using Store.Services.Customers.Contracts.Dtos;
using Store.Services.Customers.Contracts.Interface;
using Store.Services.Orders.Contracts.Dtos;
using Store.Services.Orders.Contracts.Interface;
using Store.Services.UnitOfWorks;

namespace Store.Applications.Orders.DoAddOrders;

public class DoCommandOrder(
    CustomerService customerService,
    OrderService orderService,
    UnitOfWork unitOfWork):DoAddOrder
{
    public async Task Add(DoAddingOrderDto dto)
    {
        var customerDto = new AddCustomerDto()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber
        };
        
        try
        {
            await unitOfWork.BeginTransaction();
            var customerId = await customerService.Add(customerDto);
            var orderDto = new AddOrderDto()
            {
                CustomerId = customerId,
                Details = dto.Items.Select(_=> new AddOrderDto.Detail()
                {
                    ProductId = _.ProductId,
                    Quantity = _.Quantity
                    
                }).ToList()
            };

            var orderId = await orderService.Add(orderDto);

            await unitOfWork.CommitTransaction();

        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTransaction();
            throw;
        }
      
       
       
    }
}