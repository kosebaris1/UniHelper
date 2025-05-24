using Application.Constants;
using Application.Features.MediatR.QuestionLikes.Commands;
using Application.Features.MediatR.QuestionLikes.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionLikesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionLikesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestionLikeCount(int questionId)
        {
            var value = await _mediator.Send(new GetQuestionLikeCountQuery(questionId));
            return Ok(value);
        }
        [HttpGet("is-liked")]
        public async Task<IActionResult> IsLikedByUser(int userId,int questionId)
        {
            var result = await _mediator.Send(new IsQuestionLikedByUserQuery(userId, questionId));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestionLike(CreateQuestionLikeCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<QuestionLike>.EntityAdded);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteQuestionLike(UnlikeQuestionLikeCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<QuestionLike>.EntityDeleted);
        }
    }
}
