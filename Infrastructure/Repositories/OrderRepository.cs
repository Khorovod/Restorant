using Mapster;
using Microsoft.EntityFrameworkCore;
using Orders.Domain.Models;
using Orders.Infrastructure.DbContexts;

namespace Orders.Infrastructure.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;
        
        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }
        
        public Task<List<Order>> GetAll(CancellationToken cancellationToken) => 
            _context.Orders
                .ToListAsync(cancellationToken);
        
        public async Task<Order?> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await Task.Run(() => _context.Orders
                .FirstOrDefault(o => o.Id == id), cancellationToken);
            
            return result;
        }

        public async Task<int> Create(Order order, CancellationToken cancellationToken)
        {
            _context.Orders.Add(order);
            return await _context.SaveChangesAsync(cancellationToken);
        } 
        
        public async Task<int> Update(Order order, CancellationToken cancellationToken)
        {
            _context.Orders.Update(order);
            return await _context.SaveChangesAsync(cancellationToken);
        }
        
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var item = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (item != null)
            {
                _context.Orders.Remove(item);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
