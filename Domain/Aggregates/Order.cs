using Orders.Domain.Events;
using Orders.Domain.Models;
using Orders.Domain.Models.Enums;

namespace Orders.Domain.Aggregates;

public class Order
{
    public int Id { get; set; }
    public MenuItem[] MenuItems { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalPrice { get; set; }

    
    public Order(IEnumerable<OrderEvent> events)
    {
        foreach (var orderEvent in events)
        {
            Apply(orderEvent);
        }
    }

    private void Apply(OrderEvent orderEvent)
    {
        switch (orderEvent)
        {
            case OrderCreatedEvent createdEvent:
                Id = createdEvent.Id;
                MenuItems = createdEvent.MenuItems;
                Status = createdEvent.Status;
                TotalPrice = createdEvent.MenuItems.Sum(i => i.Price);
                break;
            
            case OrderUpdateEvent updateEvent:
                MenuItems = updateEvent.MenuItems;
                Status = updateEvent.Status;
                TotalPrice = updateEvent.MenuItems.Sum(i => i.Price);

                break;
            case OrderCompletedEvent completedEvent:
                Status = completedEvent.Status;
                break;
        }
    }
}