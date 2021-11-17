using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.Data.DTO.Subscription
{
    public class SubscriptionDTO
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
        public int UserId { get; set; }
    }
}
