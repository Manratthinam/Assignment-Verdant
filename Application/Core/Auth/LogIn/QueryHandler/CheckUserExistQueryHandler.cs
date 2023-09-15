using Application.Common.Interface;
using Application.Core.Auth.LogIn.Query;
using Domain.dbDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Auth.LogIn.QueryHandler
{
    public class CheckUserExistQueryHandler : IRequestHandler<CheckUserExistQuery, User?>
    {
        private readonly IUserService _userService;
        public CheckUserExistQueryHandler(IUserService userService)
        {
            this._userService = userService;
        }
        public async Task<User?> Handle(CheckUserExistQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _userService.CheckUserExistEmail(request.Email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
