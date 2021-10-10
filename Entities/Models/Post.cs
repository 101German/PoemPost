using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string PoemText { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdationDate { get; set; }

    }
}
