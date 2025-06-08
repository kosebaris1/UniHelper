using Application.Constants;
using Application.Features.MediatR.Users.Commands;
using Application.Interfaces;
using Application.Interfaces.TokenInterface;
using Domain.Entities;
using MediatR;

namespace Application.Features.MediatR.Users.Handlers.Write
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IRepository<User> _repository;
        private readonly ITokenRepository _tokenRepository;
        public LoginCommandHandler(IRepository<User> repository, ITokenRepository tokenRepository)
        {
            _repository = repository;
            _tokenRepository = tokenRepository;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByFilterAsync(x => x.Email == request.Email && x.PasswordHash == request.Password && x.DeletedDate==null,u=>u.Role);
            if(user == null)
                throw new Exception(Messages<User>.EntityCantMatches);
            var token = _tokenRepository.GenerateToken(user);
            return token;


        }
    }
}
