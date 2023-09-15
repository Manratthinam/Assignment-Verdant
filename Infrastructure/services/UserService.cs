using Application.Common.Interface;
using Domain.dbDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.services
{
    public class UserService : IUserService
    {
        private readonly TCourtContext _dbContext;
        public UserService(TCourtContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> CheckUserExistEmail(string Email)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Email == Email);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CreateUser(User user)
        {
            try
            {
                await _dbContext.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
