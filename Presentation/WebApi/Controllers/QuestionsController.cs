using Application.Constants;
using Application.Features.MediatR.Questions.Commands;
using Application.Features.MediatR.Questions.Queries;
using Application.Features.MediatR.Users.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFilteredQuestion([FromQuery] GetFilteredQuestionQuery query)
        {
             var values=await _mediator.Send(query);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetByIdQuestionQuery(id));
            return Ok(result);
        }
        [HttpGet("TopQuestion")]
        public async Task<IActionResult> GetTopQuestion(int userId,int count)
        {
            var result = await _mediator.Send(new GetMyTopQuestionQuery(userId,count));
            return Ok(result);
        }
        [HttpGet("{id}/summary")]
        public async Task<IActionResult> GetSummary(int id)
        {
            var result = await _mediator.Send(new GetQuestionSummaryQuery(id));
            return Ok(new { summary = result });
        }
        [HttpGet("PendingQuestions")]
        public async Task<IActionResult> GetAllPendingQuestion()
        {
            var result = await _mediator.Send(new GetAllPendingQuestionQuery());
            return Ok(result);
        }
        [HttpGet("MyQuestions")]
        public async Task<IActionResult> GetMyAllQuestion(int userId)
        {
            var result = await _mediator.Send(new GetMyAllQuestionQuery(userId));
            return Ok(result);
        }
        [HttpGet("MyLikedQuestions")]
        public async Task<IActionResult> GetMyAllLikedQuestion(int userId)
        {
            var result = await _mediator.Send(new GetMyAllLikedQuestionQuery(userId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion( CreateQuestionCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Question>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateQuestion(UpdateQuestionCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Question>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Question>.EntityDeleted);
        }

        [HttpPut("approve")]  
        public async Task<IActionResult> ApproveQuestion([FromBody] ApproveQuestionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Soru onaylandı.");
        }

        [HttpPut("reject")]
        public async Task<IActionResult> RejectQuestion([FromBody] RejectQuestionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Soru reddedildi.");
        }

    }
}
