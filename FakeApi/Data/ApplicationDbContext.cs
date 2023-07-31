using FakeApi.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

namespace FakeApi.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<User> Users { get; set; }

    }
    //Alltaki kod satırları yanlış , program connection stringi hangi DbContext sınıfına bağlayacağını karıştırıyordu . Altakkiler ile yolumuzu ayırdık .
    //public class Repository : DbContext
    //{
    //    public Repository(DbContextOptions<Repository> options) : base(options) { }

    //    public DbSet<User> Users { get; set; }
    //}
    //public class Repo : DbContext
    //{
    //    public Repo(DbContextOptions<Repo> options) : base(options) { }

    //    public DbSet<Comment> Comments { get; set; }
    //}
}
