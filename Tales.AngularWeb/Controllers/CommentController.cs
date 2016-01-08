using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tales.Modal;
using Tales.Services;

namespace Tales.AngularWeb.Controllers
{
    [Authorize]
    [RoutePrefix("api/Comment")]
    public class CommentController : ApiController
    {


        private IPostService postService;
        private ITagService tagService;
        private ICommentService commentService;
        private IUserService userService;

        public CommentController(IPostService service, ITagService ts, ICommentService commentService, IUserService us)
        {
            this.postService = service;
            this.tagService = ts;
            this.userService = us;
            this.commentService = commentService;
        }


        public int Get()
        {
            var posts = commentService.GetCommentCount();
            return commentService.GetCommentCount(); ;
        }

    }
}
