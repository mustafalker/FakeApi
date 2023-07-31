using FakeApi.Data;
using FakeApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using Newtonsoft.Json;

namespace MyNamespace
{
    public class SaveToChangeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveToChangeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("typicode.com/posts")]
        public IActionResult Index()
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://jsonplaceholder.typicode.com/posts");
                var result = client.GetAsync(endpoint).Result;

                var json = result.Content.ReadAsStringAsync().Result;
                var comments = JsonConvert.DeserializeObject<List<Comment>>(json);

                foreach (var Comment in comments)
                {
                    _dbContext.Comments.Add(Comment);
                }

                _dbContext.SaveChanges();
            }

            return Ok();
        }
    }

}
