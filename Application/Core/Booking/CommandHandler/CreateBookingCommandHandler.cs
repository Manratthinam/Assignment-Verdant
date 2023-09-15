using Application.Common;
using Application.Common.Interface;
using Application.Core.Booking.Command;
using Domain.dbDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Booking.CommandHandler
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, bool>
    {
        private readonly ICurrentUser _currentUser;
        private readonly IBookingService _bookingService;
        public CreateBookingCommandHandler(ICurrentUser currentUser,IBookingService bookingService)
        {
            _currentUser = currentUser;
            _bookingService = bookingService;   
        }
        public async Task<bool> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bookingInfo = request.bookingInfo;
                Domain.dbDomain.Booking bookings = new Domain.dbDomain.Booking
                {
                    BookingDate = DateTime.Parse(bookingInfo.BookingDate).ToUniversalTime(),
                    CourtInfoId = bookingInfo.CourtId,
                    CreatedBy = _currentUser.UserId,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedBy = _currentUser.UserId,
                    ModifiedOn = DateTime.UtcNow,
                    UserId = _currentUser.UserId,
                };
                return await _bookingService.CreateBooking(bookings);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
