using Application.Interfaces.UserInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UniHelperContext _context;

        public UserRepository(UniHelperContext context)
        {
            _context = context;
        }

        public async Task ChangeStatusAsync(int userId)
        {
            var user=await _context.Users.FindAsync(userId);
            if (user == null)
                throw new Exception("Soru bulunamadı");
            user.IsVerified = true;
            user.UpdatedDate=DateTime.Now;
            await _context.SaveChangesAsync();
        }

       

        public async Task<List<User>> GetAllUserAsync()
        {
            return await _context.Users.Where(x => x.DeletedDate == null)
                .Include(x => x.Role)
                .Include(x => x.Department)
                .Include(x => x.University)
                .ToListAsync();
        }

        public async Task<User> GetByIdUserAsync(int id)
        {
            var entity = await _context.Users
                .Include(p => p.Role)
                .Include(p => p.University)
                .Include(p => p.Department)
                .Include(p => p.Answers)
                    .ThenInclude(a => a.AnswerLikes) // 🔥 önemli!
                .Include(p => p.LikedAnswers) // (istersen)
                .FirstOrDefaultAsync(p => p.UserId == id && p.DeletedDate == null);

            if (entity == null)
                throw new Exception("User bulunamadı.");

            return entity;
        }

        public async Task<User> GetByIdUserDetailsForAdminAsync(int id)
        {
            var entity = await _context.Users
               .Include(p => p.Role)
               .FirstOrDefaultAsync(p => p.UserId == id && p.DeletedDate == null);

            if (entity == null)
                throw new Exception("User bulunamadı.");
            return entity;
        }
        public async Task<List<User>> GetAllUnverifiedUserAsync()
        {
            return await _context.Users
                .Where(x => x.DeletedDate == null && x.IsVerified == false)
                .Include(x=>x.University)
                .Include(x=>x.Department)
                .ToListAsync();
        }
        public async Task<List<User>> GetRecentVerifiedUserAsync(int count)
        {
            return await _context.Users
                .Where(x => x.DeletedDate == null && x.IsVerified == true)
                .Take(count)
                .ToListAsync();
        }
    }
}
