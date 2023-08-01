using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using FakeApi.Controllers;

namespace FakeApi.Model
{

    public class User : DbContext
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }
    public class Comment : DbContext
    {
        public int id { get; set; }
        public int postId { get; set; }
        public string name { get; set; }
        public string  email { get; set; }
        public string body { get; set; }
    }
    public class FakeApi : DbContext
    {

        public DbSet<User> Users { get; set; }
        
        public DbSet<Comment> Comments { get; set; }
    }

}
