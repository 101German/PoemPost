using MediatR;
using PoemPost.Data.DTO.Subscription;
using PoemPost.Data.RequestFeauters;

namespace PoemPost.App.Queries.Subscription
{
    public class GetSubcriptionsQuery : IRequest<PagedList<SubscriptionDTO>>
    {
        public bool TrackChanges { get; set; }
        public SubscriptionParameters SubscriptionParameters { get; set; }
    }
}
