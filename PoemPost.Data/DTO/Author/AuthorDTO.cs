using System.Collections.Generic;

namespace PoemPost.Data.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostsCount { get; set; }
        public int SubscriptionsCount { get; set; }
    } 
}
