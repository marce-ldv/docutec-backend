using Model;
using Repository.Configure;
using Repository.Interface.Command;
using System.Threading.Tasks;

namespace Repository.Command
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public CommentRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task AddCommentAsync(Comment comment)
        {
            _dBContext.Comments.Add(comment);
           await _dBContext.SaveChangesAsync();
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            _dBContext.Comments.Update(comment);
            await _dBContext.SaveChangesAsync();

        }
    }
}
