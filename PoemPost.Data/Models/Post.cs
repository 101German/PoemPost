using System;
using System.Collections.Generic;

namespace PoemPost.Data.Models
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string PoemText { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }

    }
}
