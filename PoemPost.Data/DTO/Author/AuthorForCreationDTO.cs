using PoemPost.Data.Models;
using System;

namespace PoemPost.Data.DTO
{
    public class AuthorForCreationDTO
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public AuthorType AuthorType { get; set; }
    }
}
