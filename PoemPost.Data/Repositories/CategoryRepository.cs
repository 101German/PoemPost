using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;

namespace PoemPost.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
