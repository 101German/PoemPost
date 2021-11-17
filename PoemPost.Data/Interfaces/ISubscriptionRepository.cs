using PoemPost.Data.Models;
using PoemPost.Data.RequestFeauters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.Data.Interfaces
{
    public interface ISubscriptionRepository : IBaseRepository<Subscription>
    {
        Task<PagedList<Subscription>> GetWithFiltersAsync(SubscriptionParameters subscriptionParameters,bool trackChanges);
    }
}
