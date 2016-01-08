using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales.Data.Infrastructure;
using Tales.Model;

namespace Tales.Data.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();

        Category GetCategory(int categoryId);
    }
    public class CategoryRepository: RepositoryBase<Category>, ICategoryRepository 
    {
        public CategoryRepository(IDbFactory factory):base(factory)
        {

        }

        public IEnumerable<Category> GetAllCategories()
        {
            return GetAll();
        }

        public Category GetCategory(int categoryId)
        {
            return GetById(categoryId);
        }
    }
}
