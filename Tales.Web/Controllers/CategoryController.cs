using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tales.Services;

namespace Tales.Web.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;
        public CategoryController(ICategoryService cs)
        {
            this.categoryService = cs;
        }
        // GET: Category
        
        [ChildActionOnly]
        public PartialViewResult GetAllCategories()
        {
            return PartialView("_CategoryPartial", categoryService.GetCategories());
        }
    }
}