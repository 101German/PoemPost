using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.Data.Models
{
    public class Subscription : BaseEntity
    {
        public int AuthorId { get; set; }
        public int UserId { get; set; }
        public virtual Author Author { get; set; }
    }
}
