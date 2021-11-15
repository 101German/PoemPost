using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PoemPost.App.Commands;
using PoemPost.App.Commands.Update;
using PoemPost.App.Queries;
using PoemPost.App.Queries.Post;
using PoemPost.Data.DTO;
using PoemPost.Data.RequestFeauters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoemPost.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper; 

        public PostController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}",Name ="GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var post =await _mediator.Send(new GetPostByIdQuery
            {
                Id = id,
                TrackChanges = true
            });

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PostForCreationDTO post)
        {
            var postForReturn =await  _mediator.Send(new CreatePostCommand()
            {
                Post = post
            }
            );
            
            return CreatedAtRoute("GetById",new { id = postForReturn.Id},postForReturn);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PostParameters postParameters)
        {
            var postsEntities = await _mediator.Send(new GetFilteringPostsQuery()
            {
                PostParameters = postParameters,
                TrackChanges = true
            });

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(postsEntities.MetaData));
         

            var postsDTO = _mapper.Map<ICollection<PostDTO>>(postsEntities);

            return Ok(postsDTO);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeletePostCommand()
            {
                Id = id
            });

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody]PostForUpdateDTO post)
        {
            await _mediator.Send(new UpdatePostCommand()
            { 
                Id=id,
                Post=post
            
            });

            return NoContent();
        }
    }
}
