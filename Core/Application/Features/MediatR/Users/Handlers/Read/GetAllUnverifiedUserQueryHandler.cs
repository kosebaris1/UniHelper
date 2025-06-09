using Application.Features.MediatR.Users.Queries;
using Application.Features.MediatR.Users.Results;
using Application.Interfaces.UserInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Users.Handlers.Read
{
    public class GetAllUnverifiedUserQueryHandler : IRequestHandler<GetAllUnverifiedUserQuery, List<GetAllUnverifiedUserQueryResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUnverifiedUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllUnverifiedUserQueryResult>> Handle(GetAllUnverifiedUserQuery request, CancellationToken cancellationToken)
        {
            var unverifiedUsers = await _userRepository.GetAllUnverifiedUserAsync();
            return _mapper.Map<List<GetAllUnverifiedUserQueryResult>>(unverifiedUsers);
        }
    }
}
