using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Booking.Command
{
    public record DeleteMyBookingCommand(int id):IRequest<bool>;
   
}
