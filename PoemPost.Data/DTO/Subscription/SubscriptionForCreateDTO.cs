using System;

namespace PoemPost.Data.DTO.Subscription
{
    public class SubscriptionForCreateDTO
    {
        public int AuthorId { get; set; }
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
    }
}
