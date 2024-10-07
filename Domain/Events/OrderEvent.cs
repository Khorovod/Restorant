namespace Orders.Domain.Events;

public abstract class OrderEvent
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    protected OrderEvent(int id)
    {
        Id = id;
        Date = DateTime.UtcNow;
    }
}