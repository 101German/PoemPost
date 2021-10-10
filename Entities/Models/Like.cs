using System.ComponentModel.DataAnnotations;

namespace PoemPost.Data.Models
{
    public class Like
    {
        [Key]
        public int AuthorId { get; set; }
        public Author Author;

        [Key]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
