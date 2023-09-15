using Application.Common.Interface;
using Application.Core.Auth.SignIn.Command;
using Domain.dbDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Auth.SignIn.CommandHandler
{
    public class sigInCommandHandler : IRequestHandler<SigInCommand, bool>
    {
        private readonly IUserService _userService;
        public sigInCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> Handle(SigInCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sigin = request.sigin;
                User users = new User {
                    Email=sigin.Email,
                    FirstName=sigin.FirstName,
                    LastName=sigin.LastName,
                    Password=sigin.Password,
                    CreatedOn=DateTime.UtcNow
                };
                return await _userService.CreateUser(users);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
