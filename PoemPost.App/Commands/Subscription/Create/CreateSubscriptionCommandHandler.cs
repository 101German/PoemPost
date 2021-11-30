using AutoMapper;
using MediatR;
using PoemPost.Data.DTO.Subscription;
using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;
using PoemPost.Data.UserContext;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Commands
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, SubscriptionDTO>
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserContext _userContext;
        public CreateSubscriptionCommandHandler(
            IMapper mapper, 
            ISubscriptionRepository subscriptionRepository,
            IUserContext userContext)
        {
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
            _userContext = userContext;
        }
        public async Task<SubscriptionDTO> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            request.Subscription.UserEmail = _userContext.Email;
            request.Subscription.UserName = _userContext.Name;
            var subscriprionEntity = _mapper.Map<Subscription>(request.Subscription);
            _subscriptionRepository.Insert(subscriprionEntity);
            await _subscriptionRepository.SaveAsync();

            return _mapper.Map<SubscriptionDTO>(subscriprionEntity);
        }
    }
}
