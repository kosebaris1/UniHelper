using Application.Features.MediatR.Department.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var values = await _mediator.Send(new GetAllDepartmentQuery());
            return Ok(values);
        }

        [HttpGet("GetDepartmentsByUniversity")]
        public async Task<IActionResult> GetDepartmentsByUniversity(int id)
        {
            var values = await _mediator.Send(new GetDepartmentsByUniversityQuery(id));
            return Ok(values);
        }

        [HttpGet("GetAllDistinctDepartment")]
        public async Task<IActionResult> GetAllDistinctDepartment()
        {
            var result = await _mediator.Send(new GetAllDistinctDepartmentQuery());
            return Ok(result);
        }
    }
}
