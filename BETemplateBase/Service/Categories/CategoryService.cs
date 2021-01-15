using Model;
using Repository.Interface.Command;
using Repository.Interface.Query;
using Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Helper.Exceptions;

namespace Service.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryQuery _categoryQuery;

        public CategoryService(ICategoryRepository categoryRepository, ICategoryQuery categoryQuery)
        {
            _categoryRepository = categoryRepository;
            _categoryQuery = categoryQuery;
        }

        public async Task<List<Category>> GetCategoryAsync()
        {
            var listCategories = await _categoryQuery.GetCategoryListAsync();
            var aux = listCategories.Find(x => x.CategoryName == "category2");
            if (aux is null)
            {
                throw new GenericException("Categories not found");
            }
            
            return listCategories;
        }
    }
}
