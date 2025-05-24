using Application.Features.MediatR.Universities.Queries;
using Application.Features.MediatR.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class UniversityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UniversityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllUniversity")]
        public async Task<IActionResult> GetAllUniversity()
        {
            var values = await _mediator.Send(new GetAllUniversityQuery());
            return Ok(values);
        }
    }
}
