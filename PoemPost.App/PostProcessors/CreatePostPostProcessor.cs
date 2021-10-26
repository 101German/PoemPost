using MassTransit;
using MediatR;
using MediatR.Pipeline;
using PoemPost.Data.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Commands.Create
{
    public class CreatePostPostProcessor : IRequestPostProcessor<CreatePostCommand, PostDTO>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public CreatePostPostProcessor(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Process(CreatePostCommand request, PostDTO response, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish(response,cancellationToken);
        }
    }
}
