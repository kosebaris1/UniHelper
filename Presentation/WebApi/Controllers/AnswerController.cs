using Application.Constants;
using Application.Features.MediatR.Answers.Commands;
using Application.Features.MediatR.Answers.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAllAnswerByQuestion(int questionId)
        {
            var values = await _mediator.Send(new GetAllAnswerByQuestionIdQuery(questionId));
            return Ok(values);
        }
        [HttpGet("AnswerById")]
        public async Task<IActionResult> GetAnswerById(int answerId)
        {
            var value = await _mediator.Send(new GetByIdAnswerQuery(answerId));
            return Ok(value);
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
