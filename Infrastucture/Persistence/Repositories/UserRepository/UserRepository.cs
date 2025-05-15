using Application.Interfaces.UserInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UniHelperContext _context;

        public UserRepository(UniHelperContext context)
        {
            _context = context;
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
               .FirstOrDefaultAsync(p => p.UserId == id && p.DeletedDate == null);

            if (entity == null)
                throw new Exception("User bulunamadı.");
            return entity;
        }

        public Task<User> GetByIdUserDetailsForAdminAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
