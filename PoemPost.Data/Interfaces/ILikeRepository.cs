using PoemPost.Data.Models;
using System;
using System.Threading.Tasks;

namespace PoemPost.Data.Interfaces
{
    public interface ILikeRepository 
    { 
        void Add(Like like);
        Task<Like> GetAsync(int postId,Guid userId);
        void Remove(Like like);
        Task SaveAsync();

    }
}
