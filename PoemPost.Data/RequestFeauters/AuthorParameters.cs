using PoemPost.Data.Models;

namespace PoemPost.Data.RequestFeauters
{
    public class AuthorParameters : OrderParameters
    {
        public AuthorType AuthorType { get; set; }
        public string SearchTerm { get; set; }
    }
}
