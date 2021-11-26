using MediatR;
using PoemPost.Data.DTO.Subscription;
using System;

namespace PoemPost.App.Queries
{
    public class CheckExistSubscriptionQuery : IRequest<SubscriptionDTO>
    {
        public int AuthorId { get; set; }
        public Guid UserId { get; set; }
    }
}
