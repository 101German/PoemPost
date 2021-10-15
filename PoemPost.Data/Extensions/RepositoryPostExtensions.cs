using PoemPost.Data.Models;
using PoemPost.Data.RequestFeauters.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace PoemPost.Data.Extensions
{
    public static class RepositoryPostExtensions
    {
        public static IQueryable<Post> FilterByAuthors(this IQueryable<Post> posts, ICollection<string> authorsNames)
        {
            if (authorsNames == null)
            {
                return posts;
            }
           
            return posts.Where(p => authorsNames.Contains(p.Author.Name));
            
        }

        public static IQueryable<Post> FilterByDates(this IQueryable<Post> posts, DateTime startDate, DateTime finalDate) 
            => posts.Where(p => p.CreationDate == startDate || p.CreationDate == finalDate);

        public static IQueryable<Post> Search(this IQueryable<Post> posts, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return posts;
            }

            return posts.Where(p=>p.Title.Contains(searchTerm)||p.PoemText.Contains(searchTerm));

        }

        public static IQueryable<Post> Sort(this IQueryable<Post> posts,string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return posts.OrderBy(p => p.Title);
            }

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Post>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                return posts.OrderBy(p => p.Title);
            }

            return posts.OrderBy(orderQuery);
        } 

    }
}
