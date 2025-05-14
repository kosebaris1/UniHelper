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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UserId);
            _mapper.Map(request, user);
            await _repository.UpdateAsync(user);
            return Unit.Value;
        }
    }
}
