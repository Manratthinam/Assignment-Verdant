using Domain.dbDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IBookingService
    {
        Task<bool> CreateBooking(Booking bookingInfo);
        Task<Booking> GetMyBooking(int id);
        Task<bool> UpdateMyBooking(Booking bookingInfo);
        Task<bool> DeleteBooking(int id);
    }
}
