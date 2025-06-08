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
            string photoPath = null;
            string verificationPath = null;

            if (request.ProfilePictureUrl != null && request.ProfilePictureUrl.Length > 0)
            {
                var uploadsFolderPath = Path.Combine("C:\\csharpprojeler\\UniHelper\\Frontend\\UniWebUI", "wwwroot", "users");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var fileExtension = Path.GetExtension(request.ProfilePictureUrl.FileName);
                var uniqueFileName = $"{Guid.NewGuid()}_{fileExtension}";
                var filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.ProfilePictureUrl.CopyToAsync(fileStream);
                }

                photoPath = $"/users/{uniqueFileName}";

            }

            // Öğrenci belgesi işlemi (verification)
            if (request.VerificationDocumentPath != null && request.VerificationDocumentPath.Length > 0)
            {
                var verificationFolderPath = Path.Combine("C:\\csharpprojeler\\UniHelper\\Frontend\\UniWebUI", "wwwroot", "verifications");
                if (!Directory.Exists(verificationFolderPath))
                {
                    Directory.CreateDirectory(verificationFolderPath);
                }

                var fileExtension = Path.GetExtension(request.VerificationDocumentPath.FileName);
                var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                var filePath = Path.Combine(verificationFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.VerificationDocumentPath.CopyToAsync(fileStream);
                }

                verificationPath = $"/verifications/{uniqueFileName}";
            }

            var user = _mapper.Map<User>(request);
            user.RoleId = (int)UserRole.Kullanici;
            user.ProfilePictureUrl = photoPath;
            user.VerificationDocumentPath = verificationPath;
            user.IsVerified = false;
            await _repository.CreateAsync(user);
            return Unit.Value;
        }
    }
}
