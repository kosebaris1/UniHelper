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

        [HttpPost("approve/{id}")]  
        public async Task<IActionResult> ApproveQuestion(int id)
        {
            await _mediator.Send(new ApproveQuestionCommand { QuestionId = id });
            return Ok("Soru onaylandı.");
        }

        [HttpPost("reject/{id}")]
        public async Task<IActionResult> RejectQuestion(int id)
        {
            await _mediator.Send(new RejectQuestionCommand { QuestionId = id });
            return Ok("Soru reddedildi.");
        }

    }
}
