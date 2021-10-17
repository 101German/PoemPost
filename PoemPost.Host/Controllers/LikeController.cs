using MediatR;
using Microsoft.AspNetCore.Mvc;
using PoemPost.App.Commands.Like.Create;
using PoemPost.Data.DTO.Like;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LikeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LikeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]LikeForCreationDTO like)
        {
            var result = await _mediator.Send(new CreateLikeWithValidateOnExistCommand()
            {
                Like = like
            });

            return Ok(result);
        }
    }
}
