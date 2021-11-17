using Microsoft.EntityFrameworkCore;
using PoemPost.Data.Extensions;
using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;
using PoemPost.Data.RequestFeauters;
using System.Linq;
using System.Threading.Tasks;

namespace PoemPost.Data.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext RepositoryContext) : base(RepositoryContext)
        {

        }

        public async Task<PagedList<Author>> GetAuthors(AuthorParameters authorParameters, bool trackChanges)
        {
            IQueryable<Author> authorEntities = !trackChanges ?
                RepositoryContext.Set<Author>().Include(a => a.Posts).AsNoTracking() :
                RepositoryContext.Set<Author>().Include(a => a.Posts);

            var authors = await authorEntities
                .FilterByAuthorType(authorParameters.AuthorType)
                .Search(authorParameters.SearchTerm)
                .Sort(authorParameters.OrderString)
                .ToListAsync();

            return PagedList<Author>
                .ToPagedList(authors, authorParameters.PageNumber, authorParameters.PageSize);
        }
    }
}
