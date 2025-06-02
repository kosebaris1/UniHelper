using Application.Features.MediatR.Tags.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("AllTag")]
        public async Task<IActionResult> GetAllTag()
        {
            var result = await _mediator.Send(new GetAllTagQuery());
            return Ok(result);
        }
    }
}
