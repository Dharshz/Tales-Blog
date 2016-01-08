using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        BlogEntities entities;

        public BlogEntities Init()
        {
            return entities ?? (entities = new BlogEntities());
        }

        protected override void DisposeCore()
        {
            if (entities != null)
                entities.Dispose();
        }
    }
}
