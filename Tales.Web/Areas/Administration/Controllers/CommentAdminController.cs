using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tales.Model;
using Tales.Services;

namespace Tales.Web.Areas.Administration.Controllers
{
    public class CommentAdminController : Controller
    {
        private IPostService postService;


        private ICommentService commentService;
        public CommentAdminController(IPostService ps, ICommentService cs)
        {
            this.postService = ps;
            this.commentService = cs;
        }

        // GET: Administration/CommentAdmin
      
        public ActionResult ModerateComments()
        {
            IEnumerable<Post> posts = postService.GetPosts();
            if (!User.IsInRole(Tales.Utilities.Constants.USER_TYPE_ADMIN))
            {
                var tmpPosts = posts;
                posts = tmpPosts.Where(a => a.User.Id == User.Identity.GetUserId());
            }
            return View(posts);
        }


        public JsonResult RemoveComment(int commentId)
        {
            bool success = true;
            string message = string.Empty;
            try
            {
                commentService.DenyComment(commentId);
                commentService.SaveChanges();
                success = true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                success = false;           
            }
            return Json(new { Success = success, Message = message },
                                    JsonRequestBehavior.AllowGet);
        }


        public JsonResult AllowComment(int commentId)
        {
            bool success = true;
            string message = string.Empty;
            try
            {
                commentService.AllowComment(commentId);
                commentService.SaveChanges();
                success = true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                success = false;
            }
            return Json(new { Success = success, Message = message },
                                    JsonRequestBehavior.AllowGet);
        }
    }
}