using PoemPost.Data.Models;
using System.Threading.Tasks;

namespace PoemPost.Data.Interfaces
{
    public interface ILikeRepository 
    { 
        void Add(Like like);
        Task<Like> GetAsync(int postId, int authorId);
        void Remove(Like like);
        Task SaveAsync();

    }
}
