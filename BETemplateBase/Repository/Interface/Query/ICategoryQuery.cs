using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interface.Query
{
    public interface ICommentQuery
    {
        Task<List<Comment>> GetCommentListAsync();
        Task<Comment> GetCommentByIdAsync(int idComment);
        Task<Comment> DeleteByIdAsync(int idComment);
    }
}
