using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;

namespace PoemPost.Data.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(RepositoryContext RepositoryContext) : base(RepositoryContext)
        {

        }

    }
}
