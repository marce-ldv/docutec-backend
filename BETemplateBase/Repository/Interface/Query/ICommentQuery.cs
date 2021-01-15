using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interface.Query
{
    public interface ICategoryQuery
    {
        Task<List<Category>> GetCategoryListAsync();
        //Task<Comment> GetCommentByIdAsync(int idComment);
        //Task<Comment> DeleteByIdAsync(int idComment);
    }
}
