using System;

namespace PoemPost.Data.Models
{
    public class Subscription : BaseEntity
    {
        public int AuthorId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public virtual Author Author { get; set; }
    }
}
