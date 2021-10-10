using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entities
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<BaseModel>().HasQueryFilter(f => EF.Property<bool>(f, "isDeleted") == false); 

            builder.Entity<Author>().HasQueryFilter(f => EF.Property<bool>(f, "IsDeleted") == false);
            builder.Entity<Post>().HasQueryFilter(f => EF.Property<bool>(f, "IsDeleted") == false);
            builder.Entity<Comment>().HasQueryFilter(f => EF.Property<bool>(f, "IsDeleted") == false);
            builder.Entity<Like>().HasKey(l => new { l.AuthorId, l.PostId }); ;

            builder.Entity<Comment>().HasOne(c => c.Post).WithMany(p => p.Comments).HasForeignKey(c => c.PostId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Comment>().HasOne(c => c.Author).WithMany(a => a.Comments).HasForeignKey(c => c.AuthorId).OnDelete(DeleteBehavior.NoAction);


        }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
