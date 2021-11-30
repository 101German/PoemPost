using Microsoft.AspNetCore.Http;
using PoemPost.Data.Interfaces;
using PoemPost.Data.UserContext;
using PoemPost.Host.Helpers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Bookcrossing.Host.Middleware
{
    public class ConfigureUserContextMiddleware
    {
        private readonly RequestDelegate _next;

        public ConfigureUserContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IUserContext clientUserContext, IAuthorRepository authorRepository)
        {
            if (AuthorizationHelper.TryGetAuthorizationTokenFromHttpHeaders(httpContext, out string token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var tokenS = jsonToken as JwtSecurityToken;

                clientUserContext.Name = tokenS.Claims?.FirstOrDefault(x => x.Type.Equals("name", StringComparison.OrdinalIgnoreCase))?.Value;
                clientUserContext.Email = tokenS.Claims?.FirstOrDefault(x => x.Type.Equals("email", StringComparison.OrdinalIgnoreCase))?.Value;
                clientUserContext.UserId = Guid.Parse(tokenS.Claims?.FirstOrDefault(x => x.Type.Equals("sub", StringComparison.OrdinalIgnoreCase))?.Value);
                var author = await authorRepository.GetAuthorByUserId(clientUserContext.UserId);
                if (author != null)
                {
                    clientUserContext.AuthorId = author.Id;
                }
            }

            await _next.Invoke(httpContext);
        }
    }
}