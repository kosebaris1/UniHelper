using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.TokenInterface
{
    public interface ITokenRepository
    {
        public string GenerateToken(User user);
    }
}
