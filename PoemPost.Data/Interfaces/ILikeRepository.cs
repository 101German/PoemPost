using PoemPost.Data.Models;
using System.Threading.Tasks;

namespace PoemPost.Data.Interfaces
{
    public interface ILikeRepository 
    { 
        void Add(Like like);
        Task<int> GetCountByPostIdAsync(int id);
        void Remove(Like like);
    }
}
