using Application.Common.Interface;
using Application.Core.Booking.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Booking.QueryHandler
{
    public class GetMyBookingQueryHandler : IRequestHandler<GetMyBookingQuery, Domain.dbDomain.Booking>
    {
        private readonly IBookingService _bookingService;
        public GetMyBookingQueryHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<Domain.dbDomain.Booking> Handle(GetMyBookingQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _bookingService.GetMyBooking(request.bookingId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
