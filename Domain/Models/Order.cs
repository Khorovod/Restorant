using Orders.Domain.Models.Enums;

namespace Orders.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public decimal TotalCost { get; set; }
        public OrderStatus Status { get; set; }
    }
}
