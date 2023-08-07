using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;
using Tavis.UriTemplates;

namespace FakeApi
{
    public class ApiClient
    {
        private static readonly ApiClient instance = new ApiClient();
        private HttpClient client;

        private ApiClient()
        {
            client = new HttpClient();
        }

        public static ApiClient Instance => instance;

        public HttpResponseMessage GetResponse(string url)
        {
            return client.GetAsync(url).Result;
        }

        public HttpResponseMessage PostResponse(string url, object data)
        {
            var payload = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            return client.PostAsync(url, payload).Result;
        }                   
    }
    #region ApiUçları
    public static class Apiucu
    {
        public static string apiUcuPost = "https://jsonplaceholder.typicode.com/posts";
        public static string apiUcuComment = "https://jsonplaceholder.typicode.com/posts";
        public static string apiUcuPostId = "https://jsonplaceholder.typicode.com/comments?postId=";
        public static string apiUcuCommentId = "https://jsonplaceholder.typicode.com/comments";

    }
    #endregion
}