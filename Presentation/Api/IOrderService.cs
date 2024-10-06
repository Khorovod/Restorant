using Orders.Domain.Dtos;
using Orders.Domain.Models;
using Orders.Domain.Models.Enums;

namespace Orders.Presentation.Api;

public interface IOrderService
{
    Task<int> CreateOrder(OrderRequest request);
    Task DeleteOrder(int orderId);
    Task<int> ChangeOrder(OrderRequest request);
    Task<List<OrdersStatusDto>?> GetOrders();
    Task<OrdersStatusDto?> GetOrder(int orderId);
    Task<OrderStatus> CheckOrderStatus(int orderId);
    Task<decimal> GetTotalCost(int orderId);
}