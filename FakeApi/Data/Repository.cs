using FakeApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FakeApi.Data
{
    public class Repository : DbContext
    {
        public Repository(DbContextOptions<Repository> options) : base(options){}

        public DbSet<User> Users { get; set; } 
        


    }
    public class Repo : DbContext
    {
        public Repo(DbContextOptions<Repository> options) : base(options) { }

        public DbSet<Comment> Comments { get; set; }
    }

}
    