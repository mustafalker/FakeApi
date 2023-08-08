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

        [HttpPatch("{id}")]
        public IActionResult UpdateComment(int id, [FromBody] JsonPatchDocument<Comment> updatedComment)
        {
            var existingComment = _commentRepository.GetById(id);

            if (existingComment == null)
            {
                return NotFound();
            }

            updatedComment.ApplyTo(existingComment);

            _commentRepository.Update(existingComment);

            return Ok($"Yorum (ID: {id}) başarıyla güncellendi.");
        }
    }
}
#region Programın Bodysi Yani Verileri Update Etmek İsterken Body Kısmına Bu Body yi Girmemiz Lazım  
//[
//  { "op": "replace", "path": "/Name", "value": "Yeni Ad" },
//  { "op": "replace", "path": "/Email", "value": "yeni email" },
//  { "op": "replace", "path": "/Body", "value": "Yeni yorum içeriği" }
//]
#endregion
