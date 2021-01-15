using Repository.Interface.Command;
using Service.CrudComment.Add;
using Service.Interface;
using System.Threading.Tasks;
using Model;
using System;
using System.Collections.Generic;
using Repository.Interface.Query;
using Service.Dtos;
using Service.CrudComment.Update;
using Helper;

namespace Service.CrudComment
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ICommentQuery _commentQuery;

        public CommentService(ICommentRepository commentRepository, ICommentQuery commentQuery)
        {
            _commentRepository = commentRepository;
            _commentQuery = commentQuery;
        }
        public async  Task AddComment(CommentRequest commentRequest)
        {
            Comment comment = new Comment();

            comment.Description = commentRequest.Description;
            comment.Title = commentRequest.Title;
            comment.Creation = DateTime.UtcNow;

            await _commentRepository.AddCommentAsync(comment);
        }

        public async Task<bool> DeleteByIdAsync(int idComment)
        {
            var commentEntity = await _commentQuery.DeleteByIdAsync(idComment);

            if(commentEntity is null)
            {
                return false;
            }

            return true;
        }

        public async Task<CommentDto> GetCommentByIdAsync(int idComment)
        {

            var commentEntity = await _commentQuery.GetCommentByIdAsync(idComment);

            if(commentEntity is null)
            {
                return null;
            }

            var commentDto = commentEntity.MapTo<CommentDto>();

            return commentDto;

        }

        public async Task<List<Comment>> GetCommentsAsync()
        {
            var listComment = await _commentQuery.GetCommentListAsync();
            return listComment;
        }

        public async Task<CommentDto> UpdateCommentAsync(UpdateCommentRequest updateComment)
        {
            var commentEntity = await _commentQuery.GetCommentByIdAsync(updateComment.IdComment.ToInt().Value);

            if(commentEntity is null)
            {
                return null;
            }

            var commentUpdate = BuilderUpdateComment(commentEntity, updateComment);

            await _commentRepository.UpdateCommentAsync(commentUpdate);

           var commentDto = CommentDto.BuilderCommentDto(commentUpdate);

            return commentDto;
        }

        private Comment BuilderUpdateComment(Comment comment, UpdateCommentRequest updateComment)
        {
            comment.Title = updateComment.Title;
            comment.Description = updateComment.Description;
            comment.Creation = DateTime.UtcNow;

            return comment;
        }
    }
}
