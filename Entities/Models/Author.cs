﻿using System.Collections.Generic;


namespace PoemPost.Data.Models
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
