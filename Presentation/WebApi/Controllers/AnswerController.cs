using Application.Constants;
using Application.Features.MediatR.Answers.Commands;
using Application.Features.MediatR.Answers.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("AllAnswerByQuestion")]
        public async Task<IActionResult> GetAllAnswerByQuestion([FromQuery] int questionId, [FromQuery] int currentUserId)
        {
            var query = new GetAllAnswerByQuestionIdQuery(questionId, currentUserId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("AnswerById")]
        public async Task<IActionResult> GetAnswerById(int answerId)
        {
            var value = await _mediator.Send(new GetByIdAnswerQuery(answerId));
            return Ok(value);
        }
        [HttpGet("can-answer")]
        public async Task<IActionResult> CanUserAnswer(int userId, int questionId)
        {
            var result = await _mediator.Send(new CanUserAnswerQuestionQuery(userId, questionId));
            return Ok(result);
        }
        [HttpGet("RecentAnswer")]
        public async Task<IActionResult> GetRecentAsnwer(int userId, int count)
        {
            var result = await _mediator.Send(new GetRecentAnswerByUserIdQuery(userId,count));
            return Ok(result);
        }
        [HttpGet("MyAnswer")]
        public async Task<IActionResult> GetMyAnswer(int userId)
        {
            var result = await _mediator.Send(new GetMyAllAnswerQuery(userId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswer(CreateAnswersCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Answer>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAnswer(UpdateAnswerCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Answer>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAnswer(DeleteAnswerCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Answer>.EntityDeleted);
        }
    }
}
