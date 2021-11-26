using PoemPost.Data.Models;
using PoemPost.Data.RequestFeauters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoemPost.Data.Interfaces
{
    public interface ISubscriptionRepository : IBaseRepository<Subscription>
    {
        Task<PagedList<Subscription>> GetWithFiltersAsync(SubscriptionParameters subscriptionParameters,bool trackChanges);
        Task<Subscription> GetByAuthorIdAndUserId(int authorId,Guid userId);
        Task<List<Subscription>> GetByAuthorId(int authorId);
    }
}

