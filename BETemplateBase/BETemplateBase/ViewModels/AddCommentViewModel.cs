using Service.CrudComment.Add;
using System.ComponentModel.DataAnnotations;

namespace BETemplateBase.ViewModels
{
    public class AddCommentViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public CommentRequest ToBuiderCommentRequest(AddCommentViewModel addCommentViewModel)
        {
            return new CommentRequest()
            {
                Title = addCommentViewModel.Title,
                Description = addCommentViewModel.Description
            };
        }
    }
}
