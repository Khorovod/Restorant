using Orders.Domain.Aggregates;
using Orders.Domain.Events;
using Orders.Infrastructure.Projections;

namespace Orders.Infrastructure.EventStores;

public class InMemoryEventStore : IEventStore
{
    private readonly IOrdersProjection _projection;

    public InMemoryEventStore(IOrdersProjection projection)
    {
        _projection = projection;
    }
    
    private readonly List<OrderEvent> _events = new();

    public void SaveEvent(OrderEvent orderEvent)
    {
        _events.Add(orderEvent);
        
        ApplyState(orderEvent.Id);
    }

    public IEnumerable<Order> GetOrders()
    {
        return _projection.GetOrders().ToList();
    }
    
    public Order? GetOrder(int id)
    {
        return _projection.GetOrder(id);
    }
    
    
    private IEnumerable<OrderEvent> GetEvents(int id)
    {
        return _events.Where(e => e.Id == id);
    }

    private void ApplyState(int id)
    {
        var events = GetEvents(id);
        var order = new Order(events);
        _projection.ApplyState(order);
    }
}