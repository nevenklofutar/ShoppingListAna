using Entities;
using Entities.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAuthRepository
    {
        Task<User> Login(UserForLogin userForLogin);
        Task Register(UserForRegister userForRegister);
    }
}
