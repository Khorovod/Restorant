using Orders.Domain.Models.Enums;

namespace Orders.Domain.Dtos;

public class OrdersStatusDto
{
    public string Meal { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public OrderStatus Status;
}
