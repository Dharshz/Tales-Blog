
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales.Modal;
using Tales.Web.Models;

namespace Tales.Data
{
    public class StoreSeedData: DropCreateDatabaseIfModelChanges<BlogEntities>
    {
        protected override void Seed(BlogEntities context)
        {
                   
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            var user = new User { UserName = "d@a.com", Email = "d@a.com", JoinedDate = DateTime.Now, IsActive = true };

            var user2 = new User { UserName = "e@a.com", Email = "e@a.com", JoinedDate = DateTime.Now, IsActive = false };

            var result2 = userManager.Create(user2, "123456");

            var result = userManager.Create(user, "123456");

            var roleresult = roleManager.Create(new IdentityRole() { Name = Tales.Utilities.Constants.USER_TYPE_ADMIN });
            var roleresult2 = roleManager.Create(new IdentityRole() { Name = Tales.Utilities.Constants.USER_TYPE_NORMAL });

            if(result2.Succeeded)
            {
                userManager.AddToRole(user2.Id, Tales.Utilities.Constants.USER_TYPE_NORMAL);
            }

            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, Tales.Utilities.Constants.USER_TYPE_ADMIN);
            }


            Category cat = new Category() { Name="Nature", Description = "Desc"};
            Category cat2 = new Category() { Name = "People", Description = "Desc" };
            Comment com = new Comment() { Name ="D", CommentContent = "Sample Comment", IsModerated = false };
            Tag t = new Tag() { Name="Sample Tag", Description="d"};
            Tag t2 = new Tag() { Name = "Big Thinker", Description = "d" };
            Tag t3 = new Tag() { Name = "Another Tag", Description = "d" };

            Post p = new Post() { Title = "Cats Everywhere", Summery = "Bacon ipsum dolor sit amet", Description = "Bacon ipsum dolor sit amet esse duis pastrami anim, pancetta fatback capicola officia tenderloin. Meatloaf culpa ut, bacon sed sausage jerky cillum est ham ad laboris ham hock dolore. Venison ut enim, aliqua elit frankfurter et incididunt consequat culpa nostru aliqua elit pancetta.", Category = cat, Tags = new List<Tag>() { t },IsPublished = true , PublishedDate = DateTime.Now, Comments = new List<Comment>() { com }, User = user };
            Post p2 = new Post() { Title = "Big Thinkers", Summery = "Bacon ipsum dolor sit amet", Description = "Bacon ipsum dolor sit amet esse duis pastrami anim, pancetta fatback capicola officia tenderloin. Meatloaf culpa ut, bacon sed sausage jerky cillum est ham ad laboris ham hock dolore. Venison ut enim, aliqua elit frankfurter et incididunt consequat culpa nostru aliqua elit pancetta.", Category = cat2, Tags = new List<Tag>() { t, t2 }, IsPublished = false, PublishedDate = DateTime.Now, User = user2 };
            Post p3 = new Post() { Title = "Big", Summery = "pastrami anim, pancetta fatback capicola officia tenderloin. Meatloaf culpa ut, bacon sed sausage jerky cillum est ham ad laboris ham hock dolore", Description = "Bacon ipsum dolor sit amet esse duis pastrami anim, pancetta fatback capicola officia tenderloin. Meatloaf culpa ut, bacon sed sausage jerky cillum est ham ad laboris ham hock dolore. Venison ut enim, aliqua elit frankfurter et incididunt consequat culpa nostru aliqua elit pancetta.", Category = cat2, Tags = new List<Tag>() { t, t2 }, IsPublished = true, PublishedDate = DateTime.Now, User = user2 };
            Post p4 = new Post() { Title = "Thinkers",Summery = "Sample Summery", Description = "Bacon ipsum dolor sit amet esse duis pastrami anim, pancetta fatback capicola officia tenderloin. Meatloaf culpa ut, bacon sed sausage jerky cillum est ham ad laboris ham hock dolore. Venison ut enim, aliqua elit frankfurter et incididunt consequat culpa nostru aliqua elit pancetta.", Category = cat2, Tags = new List<Tag>() {  t3 }, PublishedDate = DateTime.Now, User = user };
            Post p5 = new Post() { Title = "Sample", Summery = "esse duis pastrami anim, pancetta fatback capicola", Description = "Bacon ipsum dolor sit amet esse duis pastrami anim, pancetta fatback capicola officia tenderloin. Meatloaf culpa ut, bacon sed sausage jerky cillum est ham ad laboris ham hock dolore. Venison ut enim, aliqua elit frankfurter et incididunt consequat culpa nostru aliqua elit pancetta.", Category = cat2, Tags = new List<Tag>() { t }, PublishedDate = DateTime.Now, User = user };

            context.Categories.Add(cat);
            context.Categories.Add(cat2);
            context.Comments.Add(com);
            context.Tags.Add(t);
            context.Tags.Add(t2);
            context.Tags.Add(t3);
            context.Posts.Add(p);
            context.Posts.Add(p2);
            context.Posts.Add(p3);
            context.Posts.Add(p4);
            context.Posts.Add(p5);
            context.Commit();
            base.Seed(context);
        }


     /*   private static List<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();
           
            for (int i = 0; i < 10; i++)
            {
                Post post = null;
                post = new Post() { Title = "Title " + i, Description = "Description " + i };
                posts.Add(post);
            }
            return posts;
        }

        private static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            Category cat1 = new Category()
            {
                Name = "Programming",
                Description = "Description of Cat",
                Posts = GetPosts().Where(a => a.PostId > 5).ToList()
            };

            Category sd = new Category()
            {              
                Name = "Software Dev",
                Description = "Description of Cat",
                Posts = GetPosts().Where(a => a.PostId <= 5).ToList()
            };
            categories.Add(cat1);
            categories.Add(sd);

            return categories;
        }

        private static List<Tag> GetTags()
        {
            List<Tag> tags = new List<Tag>();
            Tag t = new Tag() { Name = "Tag", Posts = GetPosts().Where(a => a.PostId < 5).ToList() };
            Tag t2 = new Tag() { Name = "Tag 2", Posts = GetPosts().Where(a => a.PostId > 5).ToList() };
            tags.Add(t);
            tags.Add(t2);

            return tags;
        }

        private static List<Comment> GetComments()
        {
            List<Comment> comments = new List<Comment>();
            Comment c = new Comment() { CommentContent = "Test Comment", Name = "D", Email = "d@abc.com", PostId = GetPosts().Where(a => a.Title.Equals("Title 1")).Select(a => a.PostId).SingleOrDefault() };
            Comment c2 = new Comment() { CommentContent = "Test Comment 2", Name = "T", Email = "d@abc.com", PostId = GetPosts().Where(a => a.Title.Equals("Title 2")).Select(a => a.PostId).SingleOrDefault() };

            comments.Add(c);
            comments.Add(c2);

            return comments;
        }
*/
    }
}
