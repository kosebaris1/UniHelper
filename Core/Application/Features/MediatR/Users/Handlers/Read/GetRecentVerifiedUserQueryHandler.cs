using Application.Features.MediatR.Users.Queries;
using Application.Features.MediatR.Users.Results;
using Application.Interfaces.UserInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Users.Handlers.Read
{
    public class GetRecentVerifiedUserQueryHandler : IRequestHandler<GetRecentVerifiedUserQuery, List<GetRecentVerifiedUserQueryResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetRecentVerifiedUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<GetRecentVerifiedUserQueryResult>> Handle(GetRecentVerifiedUserQuery request, CancellationToken cancellationToken)
        {
            var recentVerifiedUser = await _userRepository.GetRecentVerifiedUserAsync(request.Count);
            return _mapper.Map<List<GetRecentVerifiedUserQueryResult>>(recentVerifiedUser);
        }
    }
}
