using Microsoft.EntityFrameworkCore;
using TitanServices.Models;

namespace TitanServices.DTO
{
    public class ContentContext :DbContext
    {
        public ContentContext(DbContextOptions<ContentContext> options) : base(options) { }

        public DbSet<ContentModel> Contents { get; set; }
    }
}
