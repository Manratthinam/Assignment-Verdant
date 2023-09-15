using Domain.dbDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Auth.LogIn.Query
{
    public record CheckUserExistQuery(string Email):IRequest<User?>;
    
}
