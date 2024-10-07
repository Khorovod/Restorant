using Orders.Domain.Models.Enums;

namespace Orders.Domain.Events;

public class OrderCompletedEvent : OrderEvent
{
    public OrderStatus Status { get; set; }

    public OrderCompletedEvent(int id, OrderStatus status) : base(id)
    {
        Status = status;
    }
}