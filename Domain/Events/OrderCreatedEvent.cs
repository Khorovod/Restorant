using Orders.Domain.Models;
using Orders.Domain.Models.Enums;

namespace Orders.Domain.Events;

public class OrderCreatedEvent : OrderEvent
{
    public MenuItem[] MenuItems { get; set; }
    public OrderStatus Status { get; set; }
    
    public OrderCreatedEvent(int id, MenuItem[] menuItems) : base(id)
    {
        MenuItems = menuItems;
        Status = OrderStatus.Created;
    }
}