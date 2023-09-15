using Application.Common;
using Application.Common.Interface;
using Application.Core.Booking.Command;
using Application.Core.Booking.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Booking.CommandHandler
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, bool>
    {
        private readonly IBookingService _bookingService;
        private readonly ICurrentUser _currentUser;
        private readonly IMediator _mediator;
        public UpdateBookingCommandHandler(IBookingService bookingService, ICurrentUser currentUser, IMediator mediator)
        {
            _bookingService = bookingService;
            _currentUser = currentUser;
            _mediator = mediator;
        }

        public async Task<bool> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bookingToUpdate = request.bookingInfo;
                var bookingInfo = await _mediator.Send(new GetMyBookingQuery(request.bookingId));
                if(bookingInfo == null) { return false; }
                else
                {
                    bookingInfo.BookingDate=DateTime.Parse(bookingToUpdate.UpdatedBookedTime).ToUniversalTime();
                    bookingInfo.CourtInfoId = bookingToUpdate.CourtId;
                    bookingInfo.ModifiedBy = _currentUser.UserId;
                    bookingInfo.ModifiedOn = DateTime.UtcNow;
                    return await _bookingService.UpdateMyBooking(bookingInfo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
