using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.Data.RequestFeauters
{
    public class SubscriptionParameters : OrderParameters
    {
        public int UserId { get; set; }
    }
}
