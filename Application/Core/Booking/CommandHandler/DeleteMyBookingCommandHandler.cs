using Application.Common.Interface;
using Application.Core.Booking.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Booking.CommandHandler
{
    public class DeleteMyBookingCommandHandler : IRequestHandler<DeleteMyBookingCommand, bool>
    {
        private readonly IBookingService _bookingService;
        public DeleteMyBookingCommandHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public async Task<bool> Handle(DeleteMyBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _bookingService.DeleteBooking(request.id);

            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
