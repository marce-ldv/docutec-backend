using Model;
using System.Threading.Tasks;

namespace Repository.Interface.Command
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
    }
}
