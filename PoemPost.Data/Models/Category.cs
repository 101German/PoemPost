using System.Collections.Generic;

namespace PoemPost.Data.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
