using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales.Model
{
    public class Post
    {
        public int PostId { get; set; }

        public string Description { get; set; }


        public string Title { get; set; }

        public string Summery { get; set; }


        public DateTime PublishedDate { get; set; }

        public bool IsAuthorFavorite { get; set; }

     
        public bool IsPublished { get; set; }

        public virtual Category Category { get; set; }


        public virtual IList<Tag> Tags { get; set; }


        public virtual IList<Comment> Comments { get; set; }


        public virtual User User { get; set; }


    }
}
