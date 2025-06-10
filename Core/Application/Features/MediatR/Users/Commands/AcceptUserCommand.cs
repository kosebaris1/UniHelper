using MediatR;

namespace Application.Features.MediatR.Users.Commands
{
    public class AcceptUserCommand:IRequest<Unit>
    {
        public int UserId { get; set; }

        public AcceptUserCommand(int userId)
        {
            UserId = userId;
        }
    }
}
