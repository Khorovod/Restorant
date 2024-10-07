namespace Orders.Domain.Models.Enums
{
    public enum OrderStatus : byte
    {
        None = 0,
        Created = 1,
        Processing = 2,
        Delivering = 3,
        Delivered = 4,
        Canceled = 5,
        Changed = 6,
    }
}
