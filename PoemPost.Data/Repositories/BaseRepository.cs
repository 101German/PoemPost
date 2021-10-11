using Microsoft.EntityFrameworkCore;
using PoemPost.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T:BaseEntity
    {
        protected RepositoryContext RepositoryContext;

        public BaseRepository(RepositoryContext RepositoryContext)
        {
            this.RepositoryContext = RepositoryContext;
        }

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        public IQueryable<T> GetAll(bool trackChanges) => !trackChanges ?
            RepositoryContext.Set<T>().AsNoTracking()
            : RepositoryContext.Set<T>();

        public IQueryable<T> GetById(int id,bool trackChanges) => !trackChanges ?
            RepositoryContext.Set<T>().Where(e => e.Id == id).AsNoTracking()
            : RepositoryContext.Set<T>().Where(e => e.Id == id);

        public void Insert(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
       
    }
}
