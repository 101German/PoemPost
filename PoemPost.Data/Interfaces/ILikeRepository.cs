using PoemPost.Data.Models;
using System.Threading.Tasks;

namespace PoemPost.Data.Interfaces
{
    public interface ILikeRepository 
    { 
        bool AddLike(Like like);
        Task<int> GetLikesCountByPostIdAsync(int id);

    }
}
