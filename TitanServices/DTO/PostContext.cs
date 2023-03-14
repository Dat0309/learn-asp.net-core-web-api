using Microsoft.EntityFrameworkCore;
using TitanServices.Models;

namespace TitanServices.DTO
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<PostContext> options) : base(options) { }

        public DbSet<PostModel> Posts { get; set; }
    }
}
