using MediatR;
using Microsoft.AspNetCore.Mvc;
using PoemPost.App.Commands.Create;
using PoemPost.App.Commands.Delete;
using PoemPost.Data.DTO;
using System.Threading.Tasks;

namespace PoemPost.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CommentForCreationDTO comment)
        {
            var commentDTO = await _mediator.Send(new CreateCommentCommand()
            {
                Comment = comment
            });

            return Ok(commentDTO);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCommentCommand()
            {
                Id = id
            });

            return NoContent();
        }

    }
}
