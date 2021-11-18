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
            => posts.Where(p => p.CreationDate >= startDate && p.CreationDate <= finalDate);

        public static IQueryable<Post> Search(this IQueryable<Post> posts, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return posts;
            }

            return posts.Where(p => p.Title.Contains(searchTerm) || p.PoemText.Contains(searchTerm));
        }

        public static IQueryable<Post> Sort(this IQueryable<Post> posts, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return posts.OrderBy(p => p.Title);
            }

            if (orderByQueryString.Contains("likes"))
            {
                return orderByQueryString.EndsWith("desc") ?
                    posts.OrderByDescending(p => p.Likes.Count) :
                    posts.OrderBy(p => p.Likes.Count);
            }

            if (orderByQueryString.Contains("author"))
            {
                return orderByQueryString.EndsWith("desc") ?
                    posts.OrderByDescending(p => p.Author.Name) :
                    posts.OrderBy(p => p.Author.Name);
            }

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Post>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                return posts.OrderBy(p => p.Title);
            }

            return posts.OrderBy(orderQuery);
        }

        public static IQueryable<Post> FilterByAuthorId(this IQueryable<Post> posts, int authorId)
        {
            if (authorId != 0)
            {
                return posts.Where(p => p.AuthorId == authorId);
            }
            return posts;
        }

        public static IQueryable<Post> FilterByCategoryId(this IQueryable<Post> posts, int categoryId)
        {
            if (categoryId != 0)
            {
                return posts.Where(p => p.CategoryId == categoryId);
            }
            return posts;
        }
    }
}
