using Helper;
using Service.CrudComment.GetById;


namespace BETemplateBase.ViewModels
{
    public class GetCommentByIdViewModel
    {
        [IsIntValidator]
        public string IdCommment { get; set; }

        public GetCommentByIdViewModel(string idComment)
        {
            IdCommment = idComment;
        }

        public GetByIdRequest BuilderRequest(GetCommentByIdViewModel getCommentByIdView)
        {
            return new GetByIdRequest()
            {
                IdComment = getCommentByIdView.IdCommment.ToInt().Value
            };
        }
    }
}
