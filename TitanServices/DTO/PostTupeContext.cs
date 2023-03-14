using Microsoft.EntityFrameworkCore;
using TitanServices.Models;

namespace TitanServices.DTO
{
    public class PostTupeContext : DbContext
    {
        public PostTupeContext(DbContextOptions<PostTupeContext> options) : base(options) { }

        public DbSet<PostType> PostTypes { get; set; }
    }
}
