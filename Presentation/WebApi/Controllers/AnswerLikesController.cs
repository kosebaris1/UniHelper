using Application.Constants;
using Application.Features.MediatR.AnswerLikes.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerLikesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnswerLikesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswerLike(CreateAnswerLikeCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<AnswerLike>.EntityAdded);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAnswerLike(UnlikeAnswerLikeCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<AnswerLike>.EntityDeleted);
        }

    }
}
