using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales.Data.Infrastructure;
using Tales.Model;

namespace Tales.Data.Repositories
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetAllTags();

        Tag GetTagByName(string tagName);
    }
    public class TagRepository: RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory factory)  : base(factory)
        {

        }

        public IEnumerable<Tag> GetAllTags()
        {
            return GetAll();
        }

        public Tag GetTagByName(string tagName)
        {
            try
            {
                var tags = DbContext.Tags.Where(a => a.Name.ToLower() == tagName.ToLower()).ToList();
                if (!tags.Any())
                {
                    Add(new Tag() { Name = tagName, Description = "Description" });
                    DbContext.SaveChanges();
                }
            }
            catch (InvalidOperationException ioe)
            {
                throw ioe;
            }          
         
            return DbContext.Tags.Where(a => a.Name.ToLower() == tagName.ToLower()).FirstOrDefault();
        }
    }
}
