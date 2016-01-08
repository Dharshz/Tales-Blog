using ClassLibrary1;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales.Data.Configuration;
using Tales.Model;
using Tales.Web.Models;

namespace Tales.Data
{
    public class BlogEntities : IdentityDbContext<User>
    {
        public BlogEntities()
            : base("DefaultConnection")
        {

        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Category> Categories { get; set; }


        public DbSet<Comment> Comments { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Configurations.Add<Post>(new PostConfiguration());
            modelBuilder.Configurations.Add<Tag>(new TagConfiguration());
            modelBuilder.Configurations.Add<Category>(new CategoryConfiguration());
            modelBuilder.Configurations.Add<Comment>(new CommentConfiguration());


        }

        public static BlogEntities Create()
        {
            return new BlogEntities();
        }
    }
}
