using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales.Data.Infrastructure;
using Tales.Modal;

namespace Tales.Data.Repositories
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllPosts();

        Post GetPost(int postId);


        void UpdatePost(Post p);

        void AddPost(Post p);


    }
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory factory) : base(factory)
        {

        }

        public void AddPost(Post p)
        {
            this.Add(p);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return GetAll();
        }

        public Post GetPost(int postId)
        {
            return GetById(postId);
        }

        public void UpdatePost(Post p)
        {
            Update(p);
        }
    }
}
