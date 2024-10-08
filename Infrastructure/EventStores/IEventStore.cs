using Orders.Domain.Aggregates;
using Orders.Domain.Events;

namespace Orders.Infrastructure.EventStores;

public interface IEventStore
{
    void SaveEvent(OrderEvent orderEvent);
    IEnumerable<Order> GetOrders();
    Order? GetOrder(int id);
}