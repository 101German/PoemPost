using System;

namespace PoemPost.Data.RequestFeauters
{
    public class SubscriptionParameters : OrderParameters
    {
        public Guid UserId { get; set; }
    }
}
