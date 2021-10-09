using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Like
    {
        [Key]
        public int AuthorId { get; set; }
        public Author Author;

        [Key]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
