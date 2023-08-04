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
        public IActionResult GetPosts() => Ok(ApiClient.Instance.GetResponse(Apiucu.apiUcuPost).Content.ReadAsStringAsync().Result);

        [HttpGet("typicode.com/comments")]
        public IActionResult GetAllComments() => Ok(ApiClient.Instance.GetResponse(Apiucu.apiUcuComment).Content.ReadAsStringAsync().Result);

        [HttpGet("{id:int}")]
        public IActionResult GetOneUser(int id) => Ok(ApiClient.Instance.GetResponse(Apiucu.apiUcuPost).Content.ReadAsStringAsync().Result);

        [HttpPost("{id:int}")]
        public IActionResult GetPostIdComments(int id) => Ok(ApiClient.Instance.GetResponse(Apiucu.apiUcuPostId + id).Content.ReadAsStringAsync().Result);   

    }
}