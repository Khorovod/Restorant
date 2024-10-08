using Orders.Domain.Aggregates;

namespace Orders.Infrastructure.Projections;

public class OrdersProjection : IOrdersProjection
{
    private List<Order> _orders = new();

    public void ApplyState(Order order)
    {
        _orders.Add(order);
    }

    public Order? GetOrder(int orderId)
    {
        return _orders.FirstOrDefault(o => o.Id == orderId);
    }
    
    public Order[] GetOrders()
    {
        return _orders.ToArray();
    }
}