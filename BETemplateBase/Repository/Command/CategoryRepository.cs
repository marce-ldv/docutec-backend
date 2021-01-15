using Model;
using Repository.Configure;
using Repository.Interface.Command;
using System.Threading.Tasks;

namespace Repository.Command
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public CategoryRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task AddCategoryAsync(Category category)
        {
            _dBContext.Categories.Add(category);
            await _dBContext.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _dBContext.Categories.Update(category);
            await _dBContext.SaveChangesAsync();

        }
    }
}
