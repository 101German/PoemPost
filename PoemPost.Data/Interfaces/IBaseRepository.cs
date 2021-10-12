using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.Data.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(bool trackChanges);
        Task<T> GetByIdAsync(int id, bool trackChanges);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
