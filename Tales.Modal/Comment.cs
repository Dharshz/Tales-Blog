using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales.Modal
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string CommentContent { get; set; }
        public string Website { get; set; }

        public int PostId { get; set; }


        public bool IsModerated { get; set; }

        public bool IsValid { get; set; }
    
        public virtual Post Post { get; set; }
    }
}
