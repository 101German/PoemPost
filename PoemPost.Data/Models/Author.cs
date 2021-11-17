using System.Collections.Generic;

namespace PoemPost.Data.Models
{
    public enum AuthorType
    {
        Contemporary= 1,
        Classic = 2
    }
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public AuthorType AuthorType { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
