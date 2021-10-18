using PoemPost.Data.Models;
using PoemPost.Data.RequestFeauters;
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
            => posts.Where(p => p.CreationDate >= startDate && p.CreationDate <= finalDate);

        public static IQueryable<Post> Search(this IQueryable<Post> posts, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return posts;
            }

            return posts.Where(p => p.Title.Contains(searchTerm) || p.PoemText.Contains(searchTerm));

        }

        public static IQueryable<Post> Sort(this IQueryable<Post> posts, string[] orderByQueryStrings, OrderType order)
        {

            if (orderByQueryStrings == null || orderByQueryStrings.Length == 0)
            {

                return order == OrderType.Ascending
                    ? posts.OrderBy(p => p.Title)
                    : posts.OrderByDescending(p => p.Title);
            }

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Post>(orderByQueryStrings);

            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                return posts.OrderBy(p => p.Title);
            }

            return posts.OrderBy($"{orderQuery} {order}");
        }

    }
}
