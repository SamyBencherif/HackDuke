using Microsoft.EntityFrameworkCore;
using System;
using Roomly.Data.Entities;

namespace Roomly.Data
{
    public class RoomlyContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        
        public RoomlyContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasKey(c => new { c.QuestionId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
