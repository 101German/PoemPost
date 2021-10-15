
namespace PoemPost.Data.RequestFeauters
{
    public class RequestParameters
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }
        public string OrderBy { get; set; }

        private int _pageSize = 10;
    }
}
