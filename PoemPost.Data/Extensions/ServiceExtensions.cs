﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PoemPost.Data.Interfaces;
using PoemPost.Data.Mapping;
using PoemPost.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace PoemPost.Data.Extensions
{
    enum ISoftDeletable
    {
        IsDeleted
    }

    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
         services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly("PoemPost.Host")));

        public static void RegiesterSoftDeleteQueryFilter(this ModelBuilder modelBuilder, ICollection<Type> excludedTypes = null)
        {
            IEnumerable<IMutableEntityType> entityTypes = modelBuilder.Model.GetEntityTypes().Where(t => !(excludedTypes ?? new List<Type>()).Contains(t.ClrType)).ToList();

            foreach (IMutableEntityType entityType in entityTypes)
            {
                ParameterExpression parameter = Expression.Parameter(entityType.ClrType);

                MethodInfo propertyMethodInfo = typeof(Microsoft.EntityFrameworkCore.EF).GetMethod("Property").MakeGenericMethod(typeof(bool));
                MethodCallExpression isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant(nameof(ISoftDeletable.IsDeleted)));

                BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(false));

                LambdaExpression lambda = Expression.Lambda(compareExpression, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }

     
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromCallingAssembly()
            .AddClasses(classes => classes.AssignableTo(typeof(IBaseRepository<>))).AsImplementedInterfaces().WithScopedLifetime());
            services.AddScoped<ILikeRepository, LikeRepository>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AuthorProfile());
                mc.AddProfile(new PostProfile());
                mc.AddProfile(new LikeProfile());
                mc.AddProfile(new CommentProfile());
                mc.AddProfile(new SubscriptionProfile());
                mc.AddProfile(new CategoryProfile());
            });

            IMapper mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
