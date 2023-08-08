using FakeApi;
using FakeApi.Data;
using FakeApi.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FakeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddCommentFromVsController : ControllerBase
    {
        private readonly Data.FakeApiDbContext _dbContext;

        public AddCommentFromVsController(Data.FakeApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<Comment> CreateComment([FromBody] Comment newComment)
        {
            if (newComment == null)
            {
                return BadRequest("Invalid comment data.");
            }

            _dbContext.Comments.Add(newComment); 
            _dbContext.SaveChanges(); 

            return Ok(newComment);
        }
    }
}

//{
//    "postId": 123,
//  "Name": "John Doe",
//  "Email": "john@example.com",
//  "Body": "This is a comment body."
//}