using Orders.Domain.Events;

namespace Orders.Infrastructure.EventStores;

public class InMemoryEventStore : IEventStore
{
    private readonly List<OrderEvent> _events = new();

    public void SaveEvent(OrderEvent orderEvent)
    {
        _events.Add(orderEvent);
    }

    public IEnumerable<OrderEvent> GetEvents(int id)
    {
        return _events.Where(e => e.Id == id);
    }

    public IEnumerable<int> GetOrders()
    {
        return _events.GroupBy(e => e.Id).Select(g => g.Key);
    }
}