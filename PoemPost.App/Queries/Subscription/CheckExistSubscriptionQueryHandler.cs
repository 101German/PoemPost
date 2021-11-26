using AutoMapper;
using MediatR;
using PoemPost.Data.DTO.Subscription;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Queries
{
    public class CheckExistSubscriptionQueryHandler : IRequestHandler<CheckExistSubscriptionQuery, SubscriptionDTO>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;

        public CheckExistSubscriptionQueryHandler(ISubscriptionRepository subscriptionRepository,
            IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }
        public async Task<SubscriptionDTO> Handle(CheckExistSubscriptionQuery request, CancellationToken cancellationToken)
        {
            var subscription =await _subscriptionRepository.GetByAuthorIdAndUserId(request.AuthorId, request.UserId);
            return _mapper.Map<SubscriptionDTO>(subscription);
        }
    }
}
