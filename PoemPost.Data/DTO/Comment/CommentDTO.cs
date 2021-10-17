using System;

namespace PoemPost.Data.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
