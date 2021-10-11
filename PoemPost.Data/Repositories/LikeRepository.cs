using Microsoft.EntityFrameworkCore;
using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.Data.Repositories
{
    public class LikeRepository:ILikeRepository
    {
        private RepositoryContext _context;
        public LikeRepository(RepositoryContext RepositoryContext)
        {
            _context = RepositoryContext;
        }

        public bool AddLike(Like likeEntity)
        {
            var likeExist = _context.Likes.Any(l => l.PostId ==likeEntity.PostId&&l.AuthorId==likeEntity.AuthorId);
            if (likeExist)
            {
                _context.Likes.Add(likeEntity);
                return true;
            }

            _context.Remove(likeEntity);
            return false;
        }

        public async Task<int> GetLikesCountByPostIdAsync(int id)
        {
            return await _context.Posts.Where(p => p.Id == id).Include(p => p.Likes).CountAsync();
        }
    }
}
