using PoemPost.Data.Models;
using PoemPost.Data.RequestFeauters;
using System;
using System.Threading.Tasks;

namespace PoemPost.Data.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<PagedList<Author>> GetAuthors(AuthorParameters authorParameters, bool trackChanges);
        Task<Author> GetAuthorByUserId(Guid userId);
    }
}
