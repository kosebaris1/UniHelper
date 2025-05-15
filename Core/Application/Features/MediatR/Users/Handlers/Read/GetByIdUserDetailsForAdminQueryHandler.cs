using Application.Features.MediatR.Users.Queries;
using Application.Features.MediatR.Users.Results;
using Application.Interfaces.UserInterface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Users.Handlers.Read
{
    public class GetByIdUserDetailsForAdminQueryHandler : IRequestHandler<GetByIdUserDetailsForAdminQuery, GetByIdUserDetailsForAdminQueryResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetByIdUserDetailsForAdminQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdUserDetailsForAdminQueryResult> Handle(GetByIdUserDetailsForAdminQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdUserDetailsForAdminAsync(request.Id);

            return _mapper.Map<GetByIdUserDetailsForAdminQueryResult>(user);
        }
    }
}
