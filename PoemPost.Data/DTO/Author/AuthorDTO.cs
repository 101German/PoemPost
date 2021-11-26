using System;

namespace PoemPost.Data.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int PostsCount { get; set; }
        public int SubscriptionsCount { get; set; }
    } 
}
