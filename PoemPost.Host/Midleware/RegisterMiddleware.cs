using Bookcrossing.Host.Middleware;
using Microsoft.AspNetCore.Builder;

namespace PoemPost.Host.Midleware
{
    public static class RegisterMiddleware
    {
        public static void RegisterUserContextMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ConfigureUserContextMiddleware>();
        }
    }
}
