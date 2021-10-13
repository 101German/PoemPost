using PoemPost.Data.Models;
using PoemPost.Data.RequestFeauters;
using System.Threading.Tasks;

namespace PoemPost.Data.Interfaces
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Task<PagedList<Post>> GetWithFiltersAsync(PostParameters postParameters, bool trackChanges);
    }
}
