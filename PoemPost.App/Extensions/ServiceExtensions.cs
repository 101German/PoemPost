using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PoemPost.App.Validators.ValidationBehaviour;
using System.Reflection;

namespace PoemPost.App.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
        public static void ConfigureValidators(this IServiceCollection services)
        {
            services               
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
        }
    }
}
