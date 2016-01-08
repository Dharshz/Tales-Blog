using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tales.Model;

namespace Tales.Web.ViewModels
{
    public class ShowPostViewModel
    {
        public CommentViewModel CommentViewModel { get; set; }

        public string PublishedBy { get; set; }
        public Post Post { get; set; }
        public ShowPostViewModel()
        {
            CommentViewModel = new CommentViewModel();
            Post = new Post();
        }
    }
}