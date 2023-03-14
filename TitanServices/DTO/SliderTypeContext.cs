using Microsoft.EntityFrameworkCore;
using TitanServices.Models;

namespace TitanServices.DTO
{
    public class SliderTypeContext :DbContext
    {
        public SliderTypeContext(DbContextOptions<SliderTypeContext> options) : base(options) { }

        public DbSet<SliderType> SliderTypes { get; set; }
    }
}
