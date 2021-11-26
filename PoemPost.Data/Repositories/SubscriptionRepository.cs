using Microsoft.EntityFrameworkCore;
using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;
using PoemPost.Data.RequestFeauters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoemPost.Data.Repositories
{
    public class SubscriptionRepository : BaseRepository<Subscription>,ISubscriptionRepository
    {
        public SubscriptionRepository(RepositoryContext RepositoryContext) : base(RepositoryContext)
        {

        }

        public async Task<List<Subscription>> GetByAuthorId(int authorId)
        {
            return await RepositoryContext.Subscriptions
                .Where(s => s.AuthorId == authorId)
                .ToListAsync();
        }

        public async Task<Subscription> GetByAuthorIdAndUserId(int authorId, Guid userId)
        {
            return await RepositoryContext.Subscriptions
               .Where(s => s.AuthorId == authorId && s.UserId == userId)
               .FirstOrDefaultAsync();
        }

        public async Task<PagedList<Subscription>> GetWithFiltersAsync(SubscriptionParameters subscriptionParameters,bool trackChanges)
        {
            var subscriptions = await RepositoryContext.Subscriptions
                .Where(s => s.UserId == subscriptionParameters.UserId)
                .ToListAsync();

            return PagedList<Subscription>.ToPagedList(subscriptions, subscriptionParameters.PageNumber, subscriptionParameters.PageSize);
        }
    }
}
