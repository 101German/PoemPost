using System;
using System.Collections.Generic;

namespace PoemPost.Data.RequestFeauters
{
    public class PostParameters : RequestParameters
    {
        public ICollection<string> Authors { get; set; }
        public string SearchTerm { get; set; }
        public DateTime FromDateTime { get; set; } = DateTime.MinValue;
        public DateTime ToDateTime { get; set; } = DateTime.MaxValue;
    }
}
