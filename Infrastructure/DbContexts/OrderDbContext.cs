using Microsoft.EntityFrameworkCore;
using Orders.Domain.Models;

namespace Orders.Infrastructure.DbContexts
{
    internal class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) 
            : base(options) { }
        
        public DbSet<Order> Orders { get; set; }
    }
}