using MassTransit;
using MediatR.Pipeline;
using Models;
using PoemPost.Data.DTO;
using PoemPost.Data.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Commands.Create
{
    public class CreatePostPostProcessor : IRequestPostProcessor<CreatePostCommand, PostDTO>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public CreatePostPostProcessor(
            IPublishEndpoint publishEndpoint,
            ISubscriptionRepository subscriptionRepository)
        {
            _publishEndpoint = publishEndpoint;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task Process(CreatePostCommand request, PostDTO response, CancellationToken cancellationToken)
        {
            var subscriptions =await _subscriptionRepository.GetByAuthorId(response.AuthorId);
            var usersForNotify = new UsersForNotify
            {
                AuthorName = response.AuthorName,
                PoemName = response.Title
            };

            foreach (var email in subscriptions.Select(s=>s.UserEmail))
            {
                usersForNotify.UsersEmails.Add(email);
            }

            await _publishEndpoint.Publish(usersForNotify,cancellationToken);
        }
    }
}
