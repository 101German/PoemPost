using System;

namespace PoemPost.Data.Models
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
