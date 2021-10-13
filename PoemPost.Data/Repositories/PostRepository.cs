using Microsoft.EntityFrameworkCore;
using PoemPost.Data.Extensions;
using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;
using PoemPost.Data.RequestFeauters;
using System.Linq;
using System.Threading.Tasks;

namespace PoemPost.Data.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(RepositoryContext RepositoryContext) : base(RepositoryContext)
        {

        }
        public override async Task<Post> GetByIdAsync(int id, bool trackChanges) => !trackChanges ?
              await RepositoryContext.Set<Post>().Where(e => e.Id == id).Include(p => p.Comments).AsNoTracking().FirstOrDefaultAsync() :
              await RepositoryContext.Set<Post>().Where(e => e.Id == id).Include(p => p.Comments).FirstOrDefaultAsync();

        public async Task<PagedList<Post>> GetWithFiltersAsync(PostParameters postParameters, bool trackChanges)
        {
            IQueryable<Post> postsEntities = !trackChanges ? RepositoryContext.Posts.Include(p => p.Author).Include(p => p.Comments).AsNoTracking() :
                                                             RepositoryContext.Posts.Include(p => p.Author).Include(p => p.Comments);

            var posts = await postsEntities.FilterByAuthors(postParameters.Authors)
                                           .FilterByDates(postParameters.ToDateTime, postParameters.FromDateTime)
                                           .Search(postParameters.SearchTerm)
                                           .Sort(postParameters.OrderBy)
                                           .ToListAsync();

            return PagedList<Post>.ToPagedList(posts, postParameters.PageNumber, postParameters.PageSize);
        }
    }
}
