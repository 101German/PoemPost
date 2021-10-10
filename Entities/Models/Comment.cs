

namespace PoemPost.Data.Models
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
