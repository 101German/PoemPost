using System.Collections.Generic;

namespace Models
{
    public class UsersForNotify
    {
        public List<string> UsersEmails { get; set; } = new List<string>();
        public string AuthorName { get; set; }
        public string PoemName { get; set; }
    }
}
