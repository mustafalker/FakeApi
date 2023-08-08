using Microsoft.AspNetCore.Mvc;
using FakeApi.Model;
using FakeApi.Data;
using FakeApi.GenericRepositoryPattern.CommentByIdRemove.DAL;

namespace FakeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RemoveCommentController : ControllerBase
    {
        private readonly IRemove<Comment> _commentRepository;

        public RemoveCommentController(IRemove<Comment> CommentRepository)
        {
            _commentRepository = CommentRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var comment = _commentRepository.GetById(id);

            if (comment == null)
            {
                return NotFound();
            }

            _commentRepository.Remove(comment);

            return Ok($"Yorum (ID: {id}) başarıyla kaldırıldı. {comment}");
        }
        [HttpDelete("commentsby/{postId}")]
        public IActionResult GetCommentsByPostId(int postId)
        {
            var comments = _commentRepository.GetAll().Where(c => c.postId == postId).ToList();
            foreach (var comment in comments)
            {
                _commentRepository.Remove(comment);
            }

            return Ok($"{postId} gönderisine ait tüm yorumlar başarıyla kaldırıldı.");
        }
        [HttpDelete("All")]
        public IActionResult RemoveAllComment()
        {
            _commentRepository.RemoveAll();
            return Ok($"Tüm yorumlar kaldırıldı");
        }
    }
}