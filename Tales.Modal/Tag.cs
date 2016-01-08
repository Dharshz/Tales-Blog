using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales.Model
{
    public class Tag
    {
        public int TagId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}
