using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.CrudComment.Get
{
    public class GetResponseComments
    {
        public int IdComentario { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Creation { get; set; }

        public static List<GetResponseComments> FromList(List<Comment> commentsList)
        {
            return commentsList.Select(x => new GetResponseComments()
            {
                IdComentario = x.IdComentario,
                Title = x.Title,
                Description = x.Description,
                Creation = x.Creation
            }).ToList();
        }
    }
}
