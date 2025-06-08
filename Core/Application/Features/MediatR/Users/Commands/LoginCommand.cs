using MediatR;

namespace Application.Features.MediatR.Users.Commands
{
    public class LoginCommand:IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
