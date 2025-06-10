using Application.Features.MediatR.Users.Queries;
using Application.Features.MediatR.Users.Results;
using Application.Interfaces.UserInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Users.Handlers.Read
{
    public class Get3TopLikeUserQueryHandler : IRequestHandler<Get3TopLikeUserQuery, List<Get3TopLikeUserQueryResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public Get3TopLikeUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<Get3TopLikeUserQueryResult>> Handle(Get3TopLikeUserQuery request, CancellationToken cancellationToken)
        {
            var topThreeUser = await _userRepository.GetTop3VerifiedUserAsync();
            return _mapper.Map<List<Get3TopLikeUserQueryResult>>(topThreeUser);
        }
    }
}
