using Microsoft.EntityFrameworkCore;
using TitanServices.Models;

namespace TitanServices.DTO
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        public DbSet<SliderModel> Sliders { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<ContentModel> ContentModels { get; set; }
        public DbSet<SliderType> SliderTypes { get; set; }
        public DbSet<PostType> PostTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SliderType>().ToTable("SliderType");
            modelBuilder.Entity<PostType>().ToTable("PostType");
            modelBuilder.Entity<SliderModel>().ToTable("Slider");
            modelBuilder.Entity<PostModel>().ToTable("Post");
            modelBuilder.Entity<ContentModel>().ToTable("Content");

            modelBuilder.Entity<SliderModel>().HasKey(c => new { c.SlideTypeID });
        }
    }
}
