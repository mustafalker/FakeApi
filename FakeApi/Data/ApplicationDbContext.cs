using FakeApi.Model;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

namespace FakeApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> Users { get; set; }
    }
    public class Repository : DbContext
    {
        public Repository(DbContextOptions<Repository> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
    public class Repo : DbContext
    {
        public Repo(DbContextOptions<Repo> options) : base(options) { }

        public DbSet<Comment> Comments { get; set; }
    }
}
