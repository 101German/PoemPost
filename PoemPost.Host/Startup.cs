using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PoemPost.App.Extensions;
using PoemPost.Data.Extensions;
using PoemPost.Host.Extensions;
using PoemPost.Host.Midleware;
using System.Reflection;


namespace PoemPost.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureMassTransit();
            services.ConfigureAutoMapper();
            services.ConfigureValidators();
            services.ConfigureMediatR();
            services.ConfigureRepositories();
            services.ConfigureCors();
            services.ConfigureSqlContext(Configuration);
            services.AddControllers();
            services.ConfigureSwagger();
            services.AddAuthenticationSettings(Configuration);
            services.AddUserContext();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PoemPost v1"));
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.RegisterUserContextMiddleware();
            app.UseHttpsRedirection();
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("X-Pagination"));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
