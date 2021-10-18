using System.ComponentModel.DataAnnotations;

namespace PoemPost.Data.Models
{
    public class Like
    {
        [Key]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        [Key]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
