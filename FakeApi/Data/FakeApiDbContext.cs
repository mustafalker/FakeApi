using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FakeApi.Model;

namespace FakeApi.Data
{
    public class FakeApiDbContext : DbContext
    {
        public FakeApiDbContext(DbContextOptions<FakeApiDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("sqlConnection");
            }
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}