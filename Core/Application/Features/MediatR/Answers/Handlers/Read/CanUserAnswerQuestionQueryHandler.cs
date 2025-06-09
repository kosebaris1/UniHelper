using Application.Features.MediatR.Answers.Queries;
using Application.Interfaces;
using Application.Interfaces.QuestionInterface;
using Application.Interfaces.UserInterface;
using Domain.Entities;
using MediatR;

namespace Application.Features.MediatR.Answers.Handlers.Read
{
    public class CanUserAnswerQuestionQueryHandler : IRequestHandler<CanUserAnswerQuestionQuery, bool>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IRepository<User> _userRepository;

        public CanUserAnswerQuestionQueryHandler(IQuestionRepository questionRepository, IRepository<User> userRepository)
        {
            _questionRepository = questionRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CanUserAnswerQuestionQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            var question = await _questionRepository.GetQuestionWithDetailsByIdAsync(request.QuestionId);

            if (user == null || question == null)
                return false;

            // ⛔ Doğrulanmamış kullanıcıysa cevap veremez
            if (user.IsVerified != true)
                return false;

            bool hasUniversity = question.UniversityId.HasValue;
            bool hasDepartment = question.DepartmentId.HasValue;

            // 🟢 Eğer ne üniversite ne bölüm varsa → herkes cevaplayabilir
            if (!hasUniversity && !hasDepartment)
                return true;

            // 🟡 Hem üniversite hem bölüm varsa → ikisi de eşleşmeli
            if (hasUniversity && hasDepartment)
                return user.UniversityId == question.UniversityId &&
                       user.DepartmentId == question.DepartmentId;

            // 🔵 Sadece üniversite varsa
            if (hasUniversity)
                return user.UniversityId == question.UniversityId;

            // 🔴 Sadece bölüm varsa
            if (hasDepartment)
                return user.DepartmentId == question.DepartmentId;

            return false;
        }
    }
}
