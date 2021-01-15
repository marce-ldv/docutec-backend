using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Configure;
using Repository.Interface.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Query
{
    public class CategoryQuery : ICategoryQuery
    {
        private ApplicationDBContext _applicationDBContext;
        public CategoryQuery(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        //public async Task<Comment> DeleteByIdAsync(int idComment)
        //{
        //    var comment = await _applicationDBContext.Comments.FirstOrDefaultAsync(x => x.IdComentario == idComment);

        //    if(comment != null)
        //    {
        //        _applicationDBContext.Comments.Remove(comment);
        //        await _applicationDBContext.SaveChangesAsync();
        //    }

        //    return comment;
        //}

        //public Task<List<Category>> GetCategoryListAsync()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public async Task<Comment> GetCommentByIdAsync(int idComment)
        //{
        //    var comment = await _applicationDBContext.Comments.FindAsync(idComment);

        //    return comment;
        //}

        public async Task<List<Category>> GetCategoryListAsync()
        {
            var listCategory = await _applicationDBContext.Categories.ToListAsync();

            return listCategory;
        }
    }
}
