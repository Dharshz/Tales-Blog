using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales.Data.Infrastructure;
using Tales.Data.Repositories;
using Tales.Modal;

namespace Tales.Services
{
    public interface ITagService
    {
        IEnumerable<Tag> GetAllTags();

        IList<Tag> GetRelevantTag(string tagNames);
    }

    public class TagService : ITagService
    {
        private ITagRepository tagRepository;
        private IUnitOfWork iunit;
        public TagService(ITagRepository tagRepo, IUnitOfWork unitOfWork)
        {
            this.tagRepository = tagRepo;
            this.iunit = unitOfWork;
        }
        public IEnumerable<Tag> GetAllTags()
        {
            return tagRepository.GetAllTags();
        }

        public IList<Tag> GetRelevantTag(string tagNames)
        {
            string[] tags = tagNames.Split(',');
            List<Tag> tagList = new List<Tag>();
            
            foreach (string tag in tags)
            {
                tagList.Add(this.tagRepository.GetTagByName(tag));
            }

            return tagList;
        }
    }
}
