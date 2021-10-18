using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;

namespace PoemPost.Data.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext RepositoryContext) : base(RepositoryContext)
        {

        }
    }
}
