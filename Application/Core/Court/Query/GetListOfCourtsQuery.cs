using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Court.Query
{
    public record GetListOfCourtsQuery():IRequest<string>;
    
}
