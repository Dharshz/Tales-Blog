using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tales.Services;

namespace Tales.Web.Controllers
{
    public class TagController : Controller
    {
        private ITagService tagService;


        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }


        [ChildActionOnly]
        public PartialViewResult GetTags()
        {
            return PartialView("_TagPartial", tagService.GetAllTags());
        }

    }
}