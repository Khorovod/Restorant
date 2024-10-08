using Orders.Domain.Models;
using Orders.Domain.Models.Enums;

namespace Orders.Domain.Dtos;

public class OrdersStatusDto
{
    public List<MenuItem> MenuItems { get; set; }
    public string Status { get; set; }
}
