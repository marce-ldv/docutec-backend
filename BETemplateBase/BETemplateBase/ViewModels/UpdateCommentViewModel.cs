using Service.CrudComment.Update;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BETemplateBase.ViewModels
{
    public class UpdateCommentViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]

        public string Description { get; set; }

        [JsonIgnore]
        public string IdComment { get; set; }
        public UpdateCommentRequest ToBuiderCommentRequest(UpdateCommentViewModel UpdateCommentViewModel)
        {
            return new UpdateCommentRequest()
            {
                IdComment = UpdateCommentViewModel.IdComment,
                Title = UpdateCommentViewModel.Title,
                Description = UpdateCommentViewModel.Description
            };
        }
    }
}
