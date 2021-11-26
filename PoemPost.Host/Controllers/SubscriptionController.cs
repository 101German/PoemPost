using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PoemPost.App.Commands;
using PoemPost.App.Commands.Delete;
using PoemPost.App.Queries;
using PoemPost.App.Queries.Subscription;
using PoemPost.Data.DTO.Subscription;
using PoemPost.Data.RequestFeauters;
using System;
using System.Threading.Tasks;

namespace PoemPost.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SubscriptionParameters subscriptionParameters)
        {
            var subscriptionsDTO = await _mediator.Send(new GetSubcriptionsQuery()
            {
                SubscriptionParameters = subscriptionParameters,
                TrackChanges = true
            });

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(subscriptionsDTO.MetaData));

            return Ok(subscriptionsDTO.Items);
        }
        [HttpGet("checkExist")]
        public async Task<IActionResult> Get(int authorId, Guid userId)
        {
            var subscriptionIsExist = await  _mediator.Send(new CheckExistSubscriptionQuery()
            {
                UserId = userId,
                AuthorId = authorId
            });

            return Ok(subscriptionIsExist);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubscriptionForCreateDTO subscription)
        {
            var subscriptionDTO = await _mediator.Send(new CreateSubscriptionCommand()
            {
                Subscription = subscription
            });

            return Ok(subscriptionDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteSubscriptionCommand()
            {
                Id = id
            });

            return NoContent();
        }
    }
}
