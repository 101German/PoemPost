using System;

namespace PoemPost.Data.DTO.Like
{
    public class LikeForCreationDTO
    {
        public Guid UserId { get; set; }
        public int PostId { get; set; }
    }
}
