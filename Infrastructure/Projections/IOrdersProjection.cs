using Orders.Domain.Aggregates;

namespace Orders.Infrastructure.Projections;

public interface IOrdersProjection
{
    void ApplyState(Order order);
    Order? GetOrder(int orderId);
    Order[] GetOrders();
}