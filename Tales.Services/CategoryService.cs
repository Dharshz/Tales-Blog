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
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();

        Category GetCategory(int categoryId);


        void SaveChanges();

    }
    public class CategoryService : 
        ICategoryService
    {
        private ICategoryRepository categoryRepository;
        private IUnitOfWork unitOfWork;
        public CategoryService(ICategoryRepository ic, IUnitOfWork iw)
        {
            this.categoryRepository = ic;
            this.unitOfWork = iw;
        }

        public IEnumerable<Category> GetCategories()
        {
            return categoryRepository.GetAllCategories();
        }

        public Category GetCategory(int categoryId)
        {
            return categoryRepository.GetCategory(categoryId);
        }

        public void SaveChanges()
        {
            this.unitOfWork.Commit();
        }
    }
}
