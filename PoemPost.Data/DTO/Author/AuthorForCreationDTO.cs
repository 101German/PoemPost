using PoemPost.Data.Models;

namespace PoemPost.Data.DTO
{
    public class AuthorForCreationDTO
    {
        public string Name { get; set; }
        public AuthorType AuthorType { get; set; }
    }
}
