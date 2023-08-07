using FakeApi;
using FakeApi.Data;
using FakeApi.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

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

        [HttpGet("post/{id:int}")]
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

        #region Kod Doğru Ancak Api Ucunun Doğru Ucu Olmadığı İçin Tek Kayıt Alamadım Diye Düşünüyorum O Yüzden Silmek Yerine Burda Kalmasının Daha Doğru Olacağını Düşündüm 
        //[HttpGet("comment/{id:int}")]
        //public IActionResult GetCommentIdComments(int id)
        //{
        //    var response = ApiClient.Instance.GetResponse(Apiucu.apiUcuCommentId);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var json = response.Content.ReadAsStringAsync().Result;
        //        var comments = JsonConvert.DeserializeObject<List<Comment>>(json);

        //        _dbContext.Comments.AddRange(comments);
        //        _dbContext.SaveChanges();

        //        return Ok($"Veriler başarıyla eklendi. \n" + json);
        //    }
        //    else
        //    {
        //        return StatusCode((int)response.StatusCode, "Yorumlar alınamadı.");
        //    }
        //} 
        #endregion
    }
}
