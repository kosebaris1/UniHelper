using Application.Constants;
using Application.Features.MediatR.Users.Commands;
using Application.Features.MediatR.Users.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var values = await _mediator.Send(new GetAllUserQuery());
            return Ok(values);
        }

        [HttpGet("GetByIdUser")]
        public async Task<IActionResult> GetByIdUser(int id)
        {
            var value = await _mediator.Send(new GetByIdUserQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var token=await _mediator.Send(command);
            return Ok(token);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityAdded);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityDeleted);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityUpdated);
        }

    }
}
