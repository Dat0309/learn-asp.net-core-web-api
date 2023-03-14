using Microsoft.EntityFrameworkCore;
using TitanServices.Models;

namespace TitanServices.DTO
{
    public class SliderContext : DbContext
    {
        public SliderContext(DbContextOptions<SliderContext> options) : base(options) { }

        public DbSet<SliderModel> Sliders { get; set; }
    }
}
