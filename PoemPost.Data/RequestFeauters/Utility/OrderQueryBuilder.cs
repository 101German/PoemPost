using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PoemPost.Data.RequestFeauters.Utility
{
    public static class OrderQueryBuilder
    {
        public static string CreateOrderQuery<T>(string[] orderByQueryStrings)
        {
            var orderParams = orderByQueryStrings;
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                {
                    continue;
                }

                var propertyFromQueryName = param;
                var objectProperty = propertyInfos.FirstOrDefault(pi =>
                pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                {
                    continue;
                }
            

                orderQueryBuilder.Append($"{objectProperty.Name},");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' '); 

            return orderQuery;

        }
    }
}
