using FakeApi.CommentById.DAL;
using Microsoft.AspNetCore.Mvc;
using FakeApi.Model;

namespace FakeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RemoveByIdController : ControllerBase
    {
        private readonly IRepository<Comment> _commentRepository;

        public RemoveByIdController(IRepository<Comment> CommentRepository)
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

            return Ok($"Yorum (ID: {id}) başarıyla kaldırıldı." + comment);
        }
    }
}