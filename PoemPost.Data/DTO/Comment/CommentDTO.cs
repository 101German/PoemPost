using System;

namespace PoemPost.Data.DataTransferObjects
{
    public class CommentDTO
    {
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
