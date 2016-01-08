using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Tales.Services;

namespace Tales.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserAdminController : Controller
    {
        private IUserService userService;

        public UserAdminController(IUserService service)
        {
            this.userService = service;
        }
        // GET: Administration/UserAdmin
        public ActionResult Index()
        {
            ApplicationUserManager s = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var users = s.Users;
            return View(users);
        }


        public JsonResult RemoveUser(string userId)
        {
            bool success = true;
            string message = string.Empty;
            try
            {
                success = userService.RemoveUser(userId);
                if (success)
                {
                    userService.SaveChanges();
                }
                else
                {
                    message = "Unable to Remove the User";
                }
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