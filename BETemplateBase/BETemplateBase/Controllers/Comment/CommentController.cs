using BETemplateBase.ViewModels;
using Helper;
using Helper.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.CrudComment.Get;
using Service.Dtos;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BETemplateBase.Controllers.Comment
{
    [ApiController]
    [Route("Comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        IList<GetResponseComments> comments;
        CommentDto commentDto;
        bool result;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostCommentAsync([FromBody] AddCommentViewModel addComment)        
        {
            try
            {
                var addCommentRequest = addComment.ToBuiderCommentRequest(addComment);

                await _commentService.AddComment(addCommentRequest);
              
            }
            catch (Exception ex)
            {
                NotFound(ex.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCommentsAsync()
        {
            try
            {
                var listComment = await _commentService.GetCommentsAsync();

                comments = GetResponseComments.FromList(listComment);

            }
            catch(Exception ex)
            {
               return NotFound(ex.Message);
            }
            
            return Ok(comments);
        }

        [HttpGet]
        [Route("{idComment}")]
        public async Task<IActionResult> GetCommentByIdAsync(string idComment)
        {
            try
            {
                GetCommentByIdViewModel commentByIdViewModel = new GetCommentByIdViewModel(idComment);

                var getByIdrequest = commentByIdViewModel.BuilderRequest(commentByIdViewModel);

               commentDto = await _commentService.GetCommentByIdAsync(getByIdrequest.IdComment);

                if(commentDto is null)
                {
                    return BadRequest(MessageGeneral.DontExist);
                }    
        }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(commentDto);
        }

        [HttpDelete]
        [Route("{idComment}")]
        public async Task<IActionResult> DeleteCommentByIdAsync(string idComment)
        {
            try
            {
                GetCommentByIdViewModel commentByIdViewModel = new GetCommentByIdViewModel(idComment);

                var getByIdrequest = commentByIdViewModel.BuilderRequest(commentByIdViewModel);

                result = await _commentService.DeleteByIdAsync(getByIdrequest.IdComment);

                if (!result)
                {
                    return BadRequest("The Id " + idComment + " Doesn't exist.");
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(MessageGeneral.DeleteSuccess);
        }

        [HttpPatch]
        [Route("{idComment}/updateComment")]
        public async Task<IActionResult> UpdateCommentAsync(string idComment,UpdateCommentViewModel updateCommentViewModel)
        {
            try
            {

                updateCommentViewModel.IdComment = idComment;

                var updateCommentRequest = updateCommentViewModel.ToBuiderCommentRequest(updateCommentViewModel);

                commentDto = await _commentService.UpdateCommentAsync(updateCommentRequest);

                if (commentDto is null)
                {
                    return BadRequest("The Id " + idComment + " Doesn't exist.");
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            commentDto.IdComment = idComment.ToInt().Value;

            return Ok(commentDto);
        }
    }
}