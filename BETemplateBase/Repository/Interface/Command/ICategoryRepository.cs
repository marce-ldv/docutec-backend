using System.Threading.Tasks;
using Model;

namespace Repository.Interface.Command
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
    }
}
