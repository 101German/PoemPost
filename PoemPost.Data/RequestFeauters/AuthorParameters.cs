using PoemPost.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.Data.RequestFeauters
{
    public class AuthorParameters : OrderParameters
    {
        public AuthorType AuthorType { get; set; }
        public string SearchTerm { get; set; }
    }
}
