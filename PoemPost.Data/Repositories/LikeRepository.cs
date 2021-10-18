using Microsoft.EntityFrameworkCore;
using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;
using System.Threading.Tasks;

namespace PoemPost.Data.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private RepositoryContext _context;

        public LikeRepository(RepositoryContext RepositoryContext)
        {
            _context = RepositoryContext;
        }

        public void Add(Like likeEntity) => _context.Likes.Add(likeEntity);

        public async Task<Like> GetAsync(int postId, int authorId)
        {
            return await _context.Likes.SingleOrDefaultAsync(l => l.PostId == postId && l.AuthorId == authorId);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public void Remove(Like like) => _context.Likes.Remove(like);

    }
}
