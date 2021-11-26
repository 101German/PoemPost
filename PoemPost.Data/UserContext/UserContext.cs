using System;

namespace PoemPost.Data.UserContext
{
    public class UserContext : IUserContext
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int AuthorId { get; set; }
    }
}
