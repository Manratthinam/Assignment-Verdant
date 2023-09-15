using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Court.Command
{
    public record DeleteCourtInfoCommand(int courtId):IRequest<bool>;
    
}
