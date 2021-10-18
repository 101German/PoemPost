using Microsoft.EntityFrameworkCore;
using PoemPost.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoemPost.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly RepositoryContext RepositoryContext;

        public BaseRepository(RepositoryContext RepositoryContext)
        {
            this.RepositoryContext = RepositoryContext;
        }

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        public async Task<List<T>> GetAllAsync(bool trackChanges) => !trackChanges ?
              await RepositoryContext.Set<T>().AsNoTracking().ToListAsync() :
              await RepositoryContext.Set<T>().ToListAsync();

        public virtual async Task<T> GetByIdAsync(int id, bool trackChanges) => !trackChanges ?
              await RepositoryContext.Set<T>().Where(e => e.Id == id).AsNoTracking().FirstOrDefaultAsync() :
              await RepositoryContext.Set<T>().Where(e => e.Id == id).FirstOrDefaultAsync();

        public void Insert(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public async Task SaveAsync() => await RepositoryContext.SaveChangesAsync();
    }
}
