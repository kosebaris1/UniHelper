using Application.Features.MediatR.Users.Commands;
using Application.Interfaces.UserInterface;
using MediatR;

namespace Application.Features.MediatR.Users.Handlers.Write
{
    public class AcceptUserCommandHandler : IRequestHandler<AcceptUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        
        public AcceptUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(AcceptUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.ChangeStatusAsync(request.UserId);
            return Unit.Value;
        }
    }
}
