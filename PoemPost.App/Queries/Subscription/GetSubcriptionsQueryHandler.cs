using AutoMapper;
using MediatR;
using PoemPost.Data.DTO.Subscription;
using PoemPost.Data.Interfaces;
using PoemPost.Data.RequestFeauters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Queries.Subscription
{
    public class GetSubcriptionsQueryHandler : IRequestHandler<GetSubcriptionsQuery, PagedList<SubscriptionDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public GetSubcriptionsQueryHandler(IMapper mapper,ISubscriptionRepository subscriptionRepository)
        {
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
        }
        public async Task<PagedList<SubscriptionDTO>> Handle(GetSubcriptionsQuery request, CancellationToken cancellationToken)
        {
            var subscriptionEntities = await _subscriptionRepository
                .GetWithFiltersAsync(request.SubscriptionParameters, request.TrackChanges);

            return _mapper.Map<PagedList<SubscriptionDTO>>(subscriptionEntities);
        }
    }
}
