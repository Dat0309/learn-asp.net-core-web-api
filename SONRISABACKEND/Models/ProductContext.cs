using Microsoft.EntityFrameworkCore;

namespace SONRISA_BACKEND.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; } 
    }
}
