using FakeApi;
using FakeApi.Data;
using FakeApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Text;
using System.Xml.Linq;
using User = FakeApi.Model.User;

namespace Savechange.Controllers
{
    [Route("typicode.com/posts")]
    public class SaveToChangeController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public SaveToChangeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("{id:int}")]
        public IActionResult GetPostIdComments(int id)
        {

            var apiClient = ApiClient.Instance;

            var endpoint = $"https://jsonplaceholder.typicode.com/comments?postId={id}";

            var response = apiClient.GetResponse(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var comments = JsonConvert.DeserializeObject<List<Comment>>(json);

                _dbContext.Comments.AddRange(comments);
                _dbContext.SaveChanges();

                return Ok("Veriler başarıyla eklendi." + json);
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Yorumlar alınamadı.");
            }

        }
    }
}
