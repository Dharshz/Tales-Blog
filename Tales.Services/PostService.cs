using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales.Data.Infrastructure;
using Tales.Data.Repositories;
using Tales.Modal;

namespace Tales.Services
{
    public interface IPostService
    {
        IEnumerable<Post> GetPosts();

        Post GetPostById(int postId);

       
        void AddPost(Post p);


        void UpdatePost(Post post);


        void SaveChanges();
    }
    public class PostService : IPostService
    {
        private IPostRepository postRepository;

        private IUserRepository userRepository;

        private IUnitOfWork unitOfWork;

        public PostService(IPostRepository ipost, IUserRepository iuser, IUnitOfWork unitOfWork)
        {
            this.postRepository = ipost;
            this.unitOfWork = unitOfWork;
            this.userRepository = iuser;
        }
        public IEnumerable<Post> GetPosts()
        {
            return this.postRepository.GetAllPosts();
        }

        public Post GetPostById(int postId)
        {
            return this.postRepository.GetPost(postId);
        }

        public void SaveChanges()
        {
            this.unitOfWork.Commit();
        }

        public void AddPost(Post p)
        {
            this.postRepository.AddPost(p);
        }

        public void UpdatePost(Post post)
        {
            this.postRepository.UpdatePost(post);
        }

       
    }
}
