using FakeApi;
using FakeApi.Data;
using FakeApi.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FakeApi.Controllers
{
    [Route("api/[controller]")]
    public class AddCommentFromApiController : Controller
    {
        private readonly Data.FakeApiDbContext _dbContext;

        public AddCommentFromApiController(Data.FakeApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("post/{id:int}")]
        public IActionResult GetPostIdComments(int id)
        {
            var response = ApiClient.Instance.GetResponse(Apiucu.apiUcuPostId + id);

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var comments = JsonConvert.DeserializeObject<List<Comment>>(json);

                _dbContext.Comments.AddRange(comments);
                _dbContext.SaveChanges();

                return Ok($"Veriler başarıyla eklendi. \n" + json);
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Yorumlar alınamadı.");
            }
        }
    }
}
