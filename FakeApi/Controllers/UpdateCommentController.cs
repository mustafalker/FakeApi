using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using FakeApi.GenericRepositoryPattern.CommentPut.DAL;
using FakeApi.Model;

namespace FakeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateCommentController : ControllerBase
    {
        private readonly IUpdate<Comment> _commentRepository;

        public UpdateCommentController(IUpdate<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, [FromBody] Comment updatedComment)
        {
            var existingComment = _commentRepository.GetById(id);

            if (existingComment == null)
            {
                return NotFound();
            }
            existingComment.Name = updatedComment.Name;
            existingComment.Email = updatedComment.Email;
            existingComment.Body = updatedComment.Body;

            _commentRepository.Update(existingComment);

            return Ok(new { message = $"Yorum (ID: {id}) başarıyla güncellendi." });
        }
        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            Comment comment = _commentRepository.GetById(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }
        [HttpGet]
        public IActionResult GetComments()
        {
            IEnumerable<Comment> comments = _commentRepository.GetAll();

            if (comments == null)
            {
                return NotFound();
            }

            return Ok(comments);
        }
    }
}
