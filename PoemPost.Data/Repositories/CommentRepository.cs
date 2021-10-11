using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.Data.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext RepositoryContext) : base(RepositoryContext)
        {

        }
    }
}
