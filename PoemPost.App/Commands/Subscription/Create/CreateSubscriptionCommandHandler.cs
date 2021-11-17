using AutoMapper;
using MediatR;
using PoemPost.Data.DTO.Subscription;
using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Commands
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, SubscriptionDTO>
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public CreateSubscriptionCommandHandler(IMapper mapper,ISubscriptionRepository subscriptionRepository)
        {
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
        }
        public async Task<SubscriptionDTO> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscriprionEntity = _mapper.Map<Subscription>(request.Subscription);
            _subscriptionRepository.Insert(subscriprionEntity);
            await _subscriptionRepository.SaveAsync();

            return _mapper.Map<SubscriptionDTO>(subscriprionEntity);
        }
    }
}
