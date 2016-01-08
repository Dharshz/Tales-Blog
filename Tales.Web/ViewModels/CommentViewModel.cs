using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tales.Web.ViewModels
{
    public class CommentViewModel
    {
        [Required(ErrorMessage ="Name Required")]
        [MaxLength(20,ErrorMessage ="Name should be less than 20 charactors")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Content Required")]
        [DataType(DataType.Text)]
        public string CommentContent { get; set; }

        
        public string Website { get; set; }

     
        public int PostId { get; set; }

        public CommentViewModel()
        {

        }

       
    }
}