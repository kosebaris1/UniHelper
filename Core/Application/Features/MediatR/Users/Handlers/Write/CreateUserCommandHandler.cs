using Application.Enums;
using Application.Features.MediatR.Users.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Users.Handlers.Write
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            user.RoleId = (int)UserRole.Kullanici;
            await _repository.CreateAsync(user);
            return Unit.Value;
        }
    }
}
