using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;

namespace PoemPost.Data.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext RepositoryContext) : base(RepositoryContext)
        {

        }
    }
}
