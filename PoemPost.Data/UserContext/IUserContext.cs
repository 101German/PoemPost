using System;

namespace PoemPost.Data.UserContext
{
    public interface IUserContext
    {
        Guid UserId { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        int AuthorId { get; set; }
    }
}
