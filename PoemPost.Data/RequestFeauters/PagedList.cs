﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PoemPost.Data.RequestFeauters
{
    public class PagedList<T> : List<T>
    {
        public PagedList()
        {

        }
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };

            Items = items;
        }
        public MetaData MetaData { get; set; }
        public List<T> Items { get; set; }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();

            var items = source
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
