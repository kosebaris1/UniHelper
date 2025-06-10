using Application.Features.MediatR.Users.Results;
using Domain.Entities;

namespace Application.Interfaces.UserInterface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUserAsync();
        Task<User> GetByIdUserAsync(int id);
        Task<User> GetByIdUserDetailsForAdminAsync(int id);
        Task ChangeStatusAsync(int userId);
        Task<List<User>> GetAllUnverifiedUserAsync();
        Task<List<User>> GetRecentVerifiedUserAsync(int count);
        Task<List<Get3TopLikeUserQueryResult>> GetTop3VerifiedUserAsync();

    }
}
