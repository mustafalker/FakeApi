using System.Data.Entity;

namespace FakeApi.Model
{
    public class FakeApiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }  

        public DbSet<Comment> Comments { get; set; }

    }
}
