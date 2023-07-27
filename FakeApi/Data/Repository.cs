using FakeApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FakeApi.Data
{
    public class Repository : DbContext 
    {
        public static List<User> Users {  get; set; }
        static Repository() 
        {
            Users = new List<User>()
            {
                
            };
        }
        

    }
    public class Repo : DbContext 
    {
        public static List<Comment> Comments { get; set; }
        static Repo()
        {
            Comments = new List<Comment>()
            {

            };
        }
    }

}
    