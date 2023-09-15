
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Booking.Query
{
    public record GetMyBookingQuery(int bookingId):IRequest<Domain.dbDomain.Booking>;
    
}
