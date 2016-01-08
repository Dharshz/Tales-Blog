using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tales.Modal;
using Tales.Services;
using Tales.Web.ViewModels;

namespace Tales.Web.Controllers
{
    public class PostController : Controller
    {

        private IPostService postService;
        private ITagService tagService;
        private ICommentService commentService;
        private IUserService userService;
        private int size = 5;


        public PostController(IPostService service, ITagService ts, ICommentService commentService, IUserService us)
        {
            this.postService = service;
            this.tagService = ts;
            this.userService = us;
            this.commentService = commentService;
        }


       [AcceptVerbs(HttpVerbs.Get)]
        // GET: Post
        public ViewResult Index(int currentPage = 0)
        {
            List<Post> posts = postService
                              .GetPosts()
                              .Where(a => a.IsPublished)
                              .Skip(currentPage * size)
                              .Take(size).OrderByDescending(a => a.PublishedDate)
                              .ToList();

            ViewBag.CurrentPage = currentPage;
            ViewBag.HavePrevious = currentPage < 1 ? false : true;
            ViewBag.HaveNext = posts.Count() > 0 ? true : false;

            return View("Index", posts);
        }




        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ShowPost(int postId = 1)
        {
            ShowPostViewModel vm = new ShowPostViewModel();
            var post = postService.GetPostById(postId);
            vm.Post = post;
            vm.Post.Comments = null;
            vm.Post.Comments = post.Comments != null ? 
                               post.Comments.Where(a => a.IsModerated == true && a.IsValid == true).ToList() : 
                               new List<Comment>();
            vm.CommentViewModel.PostId = postId;
            vm.PublishedBy = post.User.UserName ?? string.Empty;
            return View(vm);
        }




        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShowPost(ShowPostViewModel vm)
        {
            if (ModelState.IsValid)
            {
                commentService.CreateComment(new Comment()
                {
                    CommentContent = vm.CommentViewModel.CommentContent,
                    Email = vm.CommentViewModel.Email,
                    PostId = vm.CommentViewModel.PostId,
                    Website = vm.CommentViewModel.Website,
                    Name = vm.CommentViewModel.Name,
                    IsModerated = false
                });
                commentService.SaveChanges();
                ViewBag.Message = "Your comment will show after the Moderating";
            }


            var post = postService.GetPostById(vm.CommentViewModel.PostId);
            vm.Post = post;
            vm.Post.Comments = null;
            vm.Post.Comments = post.Comments != null ?
                                 post.Comments.Where(a => a.IsModerated == true && a.IsValid == true).ToList() :
                                 new List<Comment>();
            vm.CommentViewModel = new CommentViewModel();
            return View(vm);
        }


        public PartialViewResult ShowStatistics()
        {
            StatisticsViewModel viewModel = new StatisticsViewModel()
            {
                CommentCount = commentService.GetCommentCount(),
                PostCount = postService.GetPosts().Where(a => a.IsPublished == true).Count(),
                UserCount = userService.GetUserCount()
            };

            return PartialView("_StatsPartial", viewModel);
        }

    }
}