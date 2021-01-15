using Model;
using System;

namespace Service.Dtos
{
    public class CommentDto
    {
        public int IdComment { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Creation { get; set; }

        public static CommentDto BuilderCommentDto(Comment comment)
        {
            return new CommentDto()
            {
                Title = comment.Title,
                Description = comment.Description,
                Creation = comment.Creation
            };
        }
    }
}
