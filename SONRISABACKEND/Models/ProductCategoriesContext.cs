using Microsoft.EntityFrameworkCore;

namespace SONRISA_BACKEND.Models
{
    public class ProductCategoriesContext : DbContext
    {
        public ProductCategoriesContext(DbContextOptions<ProductCategoriesContext> options) : base(options) { }
        public DbSet<ProductCategories> ProductCategories { get; set; }
    }
}
