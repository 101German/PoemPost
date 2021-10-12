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
    public class LikeRepository : ILikeRepository
    {
        private RepositoryContext _context;

        public LikeRepository(RepositoryContext RepositoryContext)
        {
            _context = RepositoryContext;
        }

        public void Add(Like likeEntity)=> _context.Likes.Add(likeEntity);

        public async Task<int> GetCountByPostIdAsync(int id)=> await _context.Likes.CountAsync(p => p.PostId == id);

        public void Remove(Like like) => _context.Likes.Remove(like);
       
    }
}
