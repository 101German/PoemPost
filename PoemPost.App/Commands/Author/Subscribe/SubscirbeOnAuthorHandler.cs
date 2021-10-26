using MassTransit;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Commands.Subscribe
{
    public class SubscirbeOnAuthorHandler : IRequestHandler<SubscribeOnAuthorCommand>
    {
        private readonly IPublishEndpoint _publishEnpoint;

        public SubscirbeOnAuthorHandler(IPublishEndpoint publisher)
        {
            _publishEnpoint = publisher;
        }

        public async Task<Unit> Handle(SubscribeOnAuthorCommand request, CancellationToken cancellationToken)
        {
            await _publishEnpoint.Publish(request.User,cancellationToken);

            return Unit.Value;
        }
    }
}
