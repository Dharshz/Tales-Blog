using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tales.AngularWeb.Models;
using Tales.Modal;
using Tales.Services;

namespace Tales.AngularWeb.Controllers
{

    public class PostsController : ApiController
    {
        private IPostService postService;
        private ITagService tagService;
        private ICommentService commentService;
        private ICategoryService categoryService;
        private IUserService userService;

        public PostsController(IPostService service, ITagService ts, ICommentService commentService, IUserService us, ICategoryService cs)
        {
            this.postService = service;
            this.tagService = ts;
            this.userService = us;
            this.commentService = commentService;
            this.categoryService = cs;
        }


        
        public IEnumerable<Post> Get()
        {
            var posts = postService.GetPosts();
            return posts;
        }


       
        public IEnumerable<Category> GetCategories()
        {
            var categories = categoryService.GetCategories();
            return categories;
        }

       
        public IEnumerable<Tag> GetTags()
        {
            return tagService.GetAllTags();
        }


       
        public Post GetPost(int postId)
        {
            return postService.GetPostById(postId);
        }


        [HttpPost]
        [ActionName("saveComment")]
        public void SaveComment(Comment c)
        {
            commentService.CreateComment(c);
        }

        [HttpGet]
        public StatisticsViewModel ShowStatistics()
        {
            StatisticsViewModel viewModel = new StatisticsViewModel()
            {
                CommentCount = commentService.GetCommentCount(),
                PostCount = postService.GetPosts().Where(a => a.IsPublished == true).Count(),
                UserCount = userService.GetUserCount()
            };

            return viewModel;
        }
       
    }
}