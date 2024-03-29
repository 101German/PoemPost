﻿
namespace PoemPost.Data.RequestFeauters
{
    public abstract class PaginationParameters
    {
        private const int MaxPageSize = 50;

        private int _pageSize = int.MaxValue;
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

    }
}
