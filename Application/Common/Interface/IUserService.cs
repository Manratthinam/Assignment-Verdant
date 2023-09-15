using Domain.dbDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IUserService
    {
        Task<bool> CreateUser(User user);
        Task<User?> CheckUserExistEmail(string Email);
    }
}
    