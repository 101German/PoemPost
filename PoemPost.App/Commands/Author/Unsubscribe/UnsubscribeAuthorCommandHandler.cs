using MassTransit;
using MediatR;
using PoemPost.App.Command.Unsubscribe;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Commands.Unsubscribe
{
    public class UnsubscribeAuthorCommandHandler : IRequestHandler<UnsubscribeAuthorCommand>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public UnsubscribeAuthorCommandHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Unit> Handle(UnsubscribeAuthorCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish(request.User, cancellationToken);

            return Unit.Value;
        }
    }
}