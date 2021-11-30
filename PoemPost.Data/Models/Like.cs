using System;
using System.ComponentModel.DataAnnotations;

namespace PoemPost.Data.Models
{
    public class Like
    {
        [Key]
        public Guid UserId { get; set; }
        [Key]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
