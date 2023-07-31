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
        //[HttpGet("typicode.com/posts")]
        //public IActionResult Index()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var endpoint = new Uri("https://jsonplaceholder.typicode.com/posts");
        //        var result = client.GetAsync(endpoint).Result;

        //        var json = result.Content.ReadAsStringAsync().Result;
        //        var comments = JsonConvert.DeserializeObject<List<Comment>>(json);

        //        foreach (var Comment in comments)
        //        {
        //            _dbContext.Comments.Add(Comment);
        //        }

        //        _dbContext.SaveChanges();
        //    }

        //    return Ok();
        //}
        //[HttpPost("{id:int}")]
        //public IActionResult GetPostIdComments(int id)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var endpoint = new Uri($"https://jsonplaceholder.typicode.com/comments?postId={id}");

        //        var result = client.GetAsync(endpoint).Result;

        //        var json = result.Content.ReadAsStringAsync().Result;

        //        var comments = JsonConvert.DeserializeObject<List<Comment>>(json);

        //        foreach (var Comment in comments)
        //        {
        //            _dbContext.Comments.Add(Comment);
        //        }

        //        _dbContext.SaveChanges();

        //        return Ok();

        //    }
        //}
        [HttpGet("{id:int}")]
        public IActionResult GetPostIdComments(int id)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri($"https://jsonplaceholder.typicode.com/comments?postId={id}");

                var result = client.GetAsync(endpoint).Result;

                if (result.IsSuccessStatusCode)
                {
                    var json = result.Content.ReadAsStringAsync().Result;
                    var comments = JsonConvert.DeserializeObject<List<Comment>>(json);

                        _dbContext.Comments.AddRange(comments);
                        _dbContext.SaveChanges();


                    return Ok("Veriler başarıyla eklendi." + json);
                }
                else
                {
                    // İstek başarısız olduysa, uygun bir yanıt döndürebilirsiniz.
                    return StatusCode((int)result.StatusCode, "Yorumlar alınamadı.");
                }
            }
        }
        [HttpPost("{id:int}")]
        public IActionResult AddComments(List<Comment> comments, int id)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri($"https://jsonplaceholder.typicode.com/comments?postId={id}");

                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;

                // API'den alınan verileri veritabanına ekle
                _dbContext.Comments.AddRange(comments);
                _dbContext.SaveChanges();

                return Ok("Veriler başarıyla eklendi." + json);
            }
        }
    }
}
