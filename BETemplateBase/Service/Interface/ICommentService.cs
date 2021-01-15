using Model;
using Service.CrudComment.Add;
using Service.CrudComment.Update;
using Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICommentService
    {
        Task AddComment(CommentRequest commentRequest);
        Task<List<Comment>> GetCommentsAsync();
        Task<CommentDto> GetCommentByIdAsync(int idComment);
        Task<bool> DeleteByIdAsync(int idComment);
        Task<CommentDto> UpdateCommentAsync(UpdateCommentRequest updateComment);
    }
}
