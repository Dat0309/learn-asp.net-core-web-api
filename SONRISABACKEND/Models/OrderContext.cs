using Microsoft.EntityFrameworkCore;

namespace SONRISA_BACKEND.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }
        public DbSet<Order> Order { get; set; }
    }
}
