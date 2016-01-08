using ClassLibrary1;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tales.Model;
using Tales.Services;
using Tales.Web.Areas.Administration.ViewModels;

namespace Tales.Web.Areas.Administration.Controllers
{
    [Authorize]
    public class PostAdminController : Controller
    {
        private ICategoryService categoryService;

        private IPostService postService;

        private ITagService tagService;

        private IUserService userService;


        public PostAdminController(ICategoryService categoryService, IPostService p, ITagService ts, IUserService us)
        {
            this.categoryService = categoryService;
            this.postService = p;
            this.tagService = ts;
            this.userService = us;
        }


        // GET: Administration/PostAdmin
        public ActionResult Index()
        {
            IEnumerable<Post> posts = postService.GetPosts();
            if (!User.IsInRole(Tales.Utilities.Constants.USER_TYPE_ADMIN))
            {
                IEnumerable<Post> tmpPosts = posts;
                posts = tmpPosts.Where(a => string.Equals(a.User.Id,User.Identity.GetUserId()));
            }

            return View(posts);
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AddPost()
        {
            PostViewModel vm = new PostViewModel();
            vm.Categories = PopulateCategories();
            return View(vm);
        }




        [AcceptVerbs(HttpVerbs.Post), ValidateInput(false)]
        public ActionResult AddPost(PostViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var post = new Post();

                post.Title = vm.Title;
                post.Description = vm.Description;
                post.PublishedDate = DateTime.Now;
                post.Summery = vm.Summery;
                post.IsPublished = vm.IsPublished;
                post.Category = categoryService.GetCategory(int.Parse(vm.Category));
                post.Tags = tagService.GetRelevantTag(vm.Tags);
                var user = userService.GetUserById(User.Identity.GetUserId());
                post.User = userService.GetUserById(User.Identity.GetUserId());
                postService.AddPost(post);
                postService.SaveChanges();
                ViewBag.Message = "Your Post Succesfully posted";
            }
            vm.Categories = PopulateCategories();
            return View(vm);
        }




        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult EditPost(int postId)
        {
            PostViewModel vm = new PostViewModel();
            var post = postService.GetPostById(postId);
            if (post != null)
            {
                vm.PostId = post.PostId;
                vm.Title = post.Title;
                vm.Description = post.Description;
                vm.Category = post.Category.Name;
                vm.Summery = post.Summery;
                vm.IsPublished = vm.IsPublished;
                vm.Tags = post.Tags != null ? string.Join(",", post.Tags.Select(a => a.Name).ToArray()) : "";
            }
            vm.Categories = PopulateCategories();
            return View(vm);
        }




        [AcceptVerbs(HttpVerbs.Post), ValidateInput(false)]
        public ActionResult EditPost(PostViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var post = new Post()
                {
                    PostId = vm.PostId,
                    Title = vm.Title,
                    Summery = vm.Summery,
                    Description = vm.Description,
                    PublishedDate = DateTime.Now,
                    IsPublished = vm.IsPublished,
                    Category = categoryService.GetCategory(int.Parse(vm.Category))
                };
                postService.UpdatePost(post);
                postService.SaveChanges();
            }
            vm.Categories = PopulateCategories();
            return View(vm);
        }










        private IList<SelectListItem> PopulateCategories()
        {
            var categories = categoryService.GetCategories();
            return categories.Select(a =>
                                        new SelectListItem()
                                        {
                                            Text = a.Name,
                                            Value = a.CategoryId.ToString()
                                        }).ToList();
        }
    }
}