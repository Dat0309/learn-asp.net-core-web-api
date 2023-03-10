﻿using Microsoft.EntityFrameworkCore;

namespace SONRISA_BACKEND.Models
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options) : base(options) { }
        public DbSet<News> News { get; set; }
    }
}
