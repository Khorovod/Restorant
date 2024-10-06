using Orders.Domain.Models;
using Orders.Domain.Models.Enums;

namespace Orders.Presentation.Api;

public class OrderRequest
{
    public int Id { get; set; }
    public MenuItem[] MenuItems { get; set; }
    public OrderStatus Status { get; set; }
}