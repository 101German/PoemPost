using System;

namespace PoemPost.Data.Models
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
