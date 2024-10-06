using Orders.Domain.Models;

namespace Orders.Infrastructure.Repositories;

public interface IOrderRepository
{
    Task<List<Order>> GetAll(CancellationToken cancellationToken);
    Task<Order?> GetById(int id, CancellationToken cancellationToken);
    Task<int> Create(Order order, CancellationToken cancellationToken);
    Task<int> Update(Order order, CancellationToken cancellationToken);
    Task Delete(int id, CancellationToken cancellationToken);
}