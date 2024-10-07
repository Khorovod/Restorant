using Orders.Domain.Models;
using Orders.Domain.Models.Enums;

namespace Orders.Domain.Events;

public class OrderUpdateEvent : OrderEvent
{
    public MenuItem[] MenuItems { get; set; }
    public OrderStatus Status { get; set; }
    
    public OrderUpdateEvent(int id, MenuItem[] menuItems) : base(id)
    {
        MenuItems = menuItems;
        Status = OrderStatus.Changed;
    }
}