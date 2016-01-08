using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tales.Web.Areas.Administration.ViewModels
{
    public class PostViewModel
    {
        public int PostId { get; set; }

        [Required(ErrorMessage ="Title Required")]
        public string Title { get; set; }

        [AllowHtml]
        [Required(ErrorMessage ="Content Required")]
        public string Description { get; set; }


        [AllowHtml]
        [Required(ErrorMessage = "Summery Required")]
        public string Summery { get; set; }

        [Required(ErrorMessage ="Add at least one tag")]
        [Display(Name ="Tags")]
        public string Tags { get; set; }


        [Required]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Publishing Status")]
        public bool IsPublished { get; set; }
        public IList<SelectListItem> Categories { get; set; }
    }
}