using PoemPost.Data.Models;
using System.Collections.Generic;

namespace PoemPost.Data.DataTransferObjects
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PoemText { get; set; }
        public int LikesCount { get; set; }

        public ICollection<CommentDTO> Comments { get; set; }
    }
}
