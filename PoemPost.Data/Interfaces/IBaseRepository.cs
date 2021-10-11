using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.Data.Interfaces
{
    public interface IBaseRepository<T> 
    {
        IQueryable<T> GetAll(bool trackChanges);
        IQueryable<T> GetById(int id,bool trackChanges);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
