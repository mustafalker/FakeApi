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
    [ApiController]
    [Route("api/[controller]")]
    public class FakeApiControllers : ControllerBase
    {
        [HttpGet("typicode.com/posts")]
        public IActionResult GetPosts()
        {
            var apiClient = ApiClient.Instance;

            var endpoint = Apiucu.apiUcuPost;

            var response = apiClient.GetResponse(endpoint);

            var json = response.Content.ReadAsStringAsync().Result;

            return Ok(json);
        }

        [HttpGet("typicode.com/comments")]
        public IActionResult GetAllComments()
        {
            var apiClient = ApiClient.Instance;

            var endpoint = Apiucu.apiUcuComment;

            var response = apiClient.GetResponse(endpoint);

            var json = response.Content.ReadAsStringAsync().Result;

            return Ok(json);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneUser(int id)
        {
            var apiClient = ApiClient.Instance;

            var endpoint = Apiucu.apiUcuPost;

            var newPost = new Model.User();

            var response = apiClient.PostResponse(endpoint, newPost);

            var result = response.Content.ReadAsStringAsync().Result;

            return Ok(result);
        }

        [HttpPost("{id:int}")]
        public IActionResult GetPostIdComments(int id)
        {
            var apiClient = ApiClient.Instance;

            var endpoint = $"https://jsonplaceholder.typicode.com/comments?postId={id}";

            var response = apiClient.GetResponse(endpoint);

            var result = response.Content.ReadAsStringAsync().Result;

            return Ok(result);
        }
    }
}
