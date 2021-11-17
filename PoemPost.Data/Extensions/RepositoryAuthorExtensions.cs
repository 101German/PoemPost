using PoemPost.Data.Models;
using PoemPost.Data.RequestFeauters.Utility;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace PoemPost.Data.Extensions
{
    public static class RepositoryAuthorExtensions
    {
        public static IQueryable<Author> FilterByAuthorType(this IQueryable<Author> authors, AuthorType authorType)
        {
            if (authorType == 0)
            {
                return authors;
            }
            return authors.Where(a => a.AuthorType == authorType);
        }

        public static IQueryable<Author> Search(this IQueryable<Author> authors, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return authors;
            }

            return authors.Where(a => a.Name.Contains(searchTerm));
        }

        public static IQueryable<Author> Sort(this IQueryable<Author> authors, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return authors.OrderBy(a => a.Name);
            }

            if (orderByQueryString.Contains("subscriptionsCount"))
            {
                return orderByQueryString.EndsWith("desc") ?
                    authors.OrderByDescending(a => a.Subscriptions.Count) :
                    authors.OrderBy(a => a.Subscriptions.Count);
            }

            if (orderByQueryString.Contains("postsCount"))
            {
                return orderByQueryString.EndsWith("desc") ?
                    authors.OrderByDescending(a => a.Posts.Count) :
                    authors.OrderBy(a => a.Posts.Count);
            }

            var orderQuery = OrderQueryBuilder
                .CreateOrderQuery<Author>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                return authors.OrderBy(a => a.Name);
            }

            return authors.OrderBy(orderQuery);
        }
    }
}
