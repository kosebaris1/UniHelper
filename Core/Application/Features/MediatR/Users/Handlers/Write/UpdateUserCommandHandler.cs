using Application.Features.MediatR.Users.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

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

            string photoPath = user.ProfilePictureUrl;
            string verificationPath = user.VerificationDocumentPath;

            // Profil fotoğrafı güncelleme
            if (request.ProfilePictureUrl != null && request.ProfilePictureUrl.Length > 0)
            {
                // Eski fotoğrafı sil (varsa)
                if (!string.IsNullOrEmpty(user.ProfilePictureUrl))
                {
                    var oldPhotoFullPath = Path.Combine("C:\\Users\\furka\\Source\\Repos\\UniHelper\\Frontend\\UniWebUI", "wwwroot", user.ProfilePictureUrl.TrimStart('/'));
                    if (File.Exists(oldPhotoFullPath))
                    {
                        File.Delete(oldPhotoFullPath);
                    }
                }

                var uploadsFolderPath = Path.Combine("C:\\Users\\furka\\Source\\Repos\\UniHelper\\Frontend\\UniWebUI", "wwwroot", "users");
                Directory.CreateDirectory(uploadsFolderPath); // garantili oluşturma

                var fileExtension = Path.GetExtension(request.ProfilePictureUrl.FileName);
                var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                var filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.ProfilePictureUrl.CopyToAsync(fileStream);
                }

                photoPath = $"/users/{uniqueFileName}";
            }

            // Öğrenci belgesi güncelleme
            if (request.VerificationDocumentPath != null && request.VerificationDocumentPath.Length > 0)
            {
                // Eski belgeyi sil (varsa)
                if (!string.IsNullOrEmpty(user.VerificationDocumentPath))
                {
                    var oldDocFullPath = Path.Combine("C:\\Users\\furka\\Source\\Repos\\UniHelper\\Frontend\\UniWebUI", "wwwroot", user.VerificationDocumentPath.TrimStart('/'));
                    if (File.Exists(oldDocFullPath))
                    {
                        File.Delete(oldDocFullPath);
                    }
                }

                var verificationFolderPath = Path.Combine("C:\\Users\\furka\\Source\\Repos\\UniHelper\\Frontend\\UniWebUI", "wwwroot", "verifications");
                Directory.CreateDirectory(verificationFolderPath);

                var fileExtension = Path.GetExtension(request.VerificationDocumentPath.FileName);
                var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                var filePath = Path.Combine(verificationFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.VerificationDocumentPath.CopyToAsync(fileStream);
                }

                verificationPath = $"/verifications/{uniqueFileName}";
            }

            // Map ve güncelle
            _mapper.Map(request, user);
            user.ProfilePictureUrl = photoPath;
            user.VerificationDocumentPath = verificationPath;

            await _repository.UpdateAsync(user);
            return Unit.Value;
        }

    }
}
