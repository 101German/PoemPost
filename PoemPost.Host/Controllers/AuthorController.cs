using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using PoemPost.App.Command.Unsubscribe;
using PoemPost.App.Commands;
using PoemPost.App.Commands.Subscribe;
using PoemPost.App.Queries;
using PoemPost.Data.DTO;
using System.Threading.Tasks;

namespace PoemPost.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AuthorForCreationDTO author)
        {
            var authorDTO = await  _mediator.Send(new CreateAuthorCommand()
            {
                Author = author
            });

            return Ok(authorDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var authorDTO = await _mediator.Send(new GetAuthorByIdQuery()
            {
                Id = id,
                TrackChanges = false
            });

            return Ok(authorDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var authorDTO = await _mediator.Send(new GetAuthorsQuery()
            {
                TrackChanges = false
            });

            return Ok(authorDTO);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteAuthorCommand()
            {
                Id = id
            });

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id,[FromBody]AuthorForUpdateDTO author)
        {
            await _mediator.Send(new UpdateAuthorCommand()
            {
                Id = id,
                Author = author
            });

            return NoContent();
        }

        [HttpPost("Subscribe")]
        public async Task<IActionResult> Subscribe(UserForSubscription user)
        {
            await _mediator.Send(new SubscribeOnAuthorCommand()
            {
                User = user
            });

            return NoContent();
        }

        [HttpPost("Unsubscribe")]
        public async Task<IActionResult> Unsubscribe(UserForUnsubscription user)
        {
            await _mediator.Send(new UnsubscribeAuthorCommand()
            {
                User = user
            });

            return NoContent();
        }

    }
}
