using Store.Applications.Orders.DoAddOrders.Contracts.Dto;

namespace Store.Applications.Orders.DoAddOrders.Contracts.interfaces;

public interface DoAddOrder
{
    Task Add(DoAddingOrderDto dto);
}