using Orders.Domain.Events;

namespace Orders.Infrastructure.EventStores;

public interface IEventStore
{
    void SaveEvent(OrderEvent orderEvent);
    IEnumerable<OrderEvent> GetEvents(int id);
    IEnumerable<int> GetOrders();
}