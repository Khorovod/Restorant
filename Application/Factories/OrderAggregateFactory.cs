using Orders.Domain.Aggregates;
using Orders.Infrastructure.EventStores;

namespace Orders.Application.Factories;

public class OrderAggregateFactory
{
    private readonly IEventStore _eventStore;

    public OrderAggregateFactory(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    public Order CreateOrderAggregate(int orderId)
    {
        var events = _eventStore.GetEvents(orderId);
        return new Order(events);
    }

    public Order[] CreateAllOrderAggregates()
    {
        var orders = _eventStore.GetOrders();

        return orders.Select(CreateOrderAggregate).ToArray();
    }
}