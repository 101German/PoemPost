using MediatR;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Commands.Delete
{
    public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public DeleteSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }
        public async Task<Unit> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscriptionEntity = await _subscriptionRepository.GetByIdAsync(request.Id, trackChanges: true);

            _subscriptionRepository.Delete(subscriptionEntity);
            await _subscriptionRepository.SaveAsync();

            return Unit.Value;
        }
    }
}
