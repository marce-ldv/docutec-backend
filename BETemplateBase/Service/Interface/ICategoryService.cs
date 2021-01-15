using System.Collections.Generic;
using Model;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICategoryService
    {
        // Task AddComment(CommentRequest commentRequest);
        Task<List<Category>> GetCategoryAsync();
        // Task<CommentDto> GetCommentByIdAsync(int idComment);
        // Task<bool> DeleteByIdAsync(int idComment);
        // Task<CommentDto> UpdateCommentAsync(UpdateCommentRequest updateComment);
    }
}
