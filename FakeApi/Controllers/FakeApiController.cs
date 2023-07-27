using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using System;
using System.Text;
using System.Text.Json.Serialization;
using FakeApi.Model;
using FakeApi.Data;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace FakeApi.Controllers
{
    [Route("typicode.com")]
    [ApiController]
    public class FakeApiController : Controller
    {
        [HttpGet("typicode.com/posts")]
        public IActionResult Index()
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://jsonplaceholder.typicode.com/posts");

                var result = client.GetAsync(endpoint).Result;

                var json = result.Content.ReadAsStringAsync().Result;

                return Ok(json);
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneUser([FromRoute(Name = "id")] int id)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://jsonplaceholder.typicode.com/posts");

                var newPost = new Model.User();

                var newPostJson = JsonConvert.SerializeObject(newPost);

                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

                var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;

                return Ok(result);
            }
        }
        [HttpGet("typicode.com/comments")]
        public IActionResult GetAllComments()
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://jsonplaceholder.typicode.com/comments");

                var result = client.GetAsync(endpoint).Result;

                var json = result.Content.ReadAsStringAsync().Result;

                return Ok(json);

            }
        }

        #region Yanlış
        //[HttpGet(("{id:int}"))]
        //public IActionResult GetOneComments(int id)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var endpoint = new Uri("https://jsonplaceholder.typicode.com/comments?postId=1");

        //        var newPost = new Model.Comment();

        //        var newPostJson = JsonConvert.SerializeObject(newPost);

        //        var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

        //        var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;

        //        return Ok(result);

        //    }
        //} 
        #endregion

        [HttpPost("{id:int}")]
        public IActionResult GetPostIdComments(int id)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri($"https://jsonplaceholder.typicode.com/comments?postId={id}");

                var result = client.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;

                return Ok(result);

            }
        }
    }
}
