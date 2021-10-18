using System.Collections.Generic;

namespace PoemPost.Data.Models
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
