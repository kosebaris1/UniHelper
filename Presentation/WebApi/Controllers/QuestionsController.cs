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

        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromQuery] CreateQuestionCommand command)
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
        
    }
}
