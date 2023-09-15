using Application.Common.Interface;
using Domain.dbDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.services
{
    public class BookingService : IBookingService
    {
        private readonly TCourtContext _dbContext;
        public BookingService(TCourtContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateBooking(Booking bookingInfo)
        {
            try
            {
                await _dbContext.AddAsync(bookingInfo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteBooking(int id)
        {
            try
            {
                var bookingItem=await _dbContext.Bookings.FirstOrDefaultAsync(x=>x.BookingId==id);
                _dbContext.Bookings.Remove(bookingItem);
                _dbContext.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Booking> GetMyBooking(int id)
        {
            try
            {
                var bookingDetail = await _dbContext.Bookings.Where(x=>x.BookingId == id)
                                    .FirstOrDefaultAsync();
                return bookingDetail;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateMyBooking(Booking bookingInfo)
        {
            try
            {
                _dbContext.Update(bookingInfo);
                await _dbContext.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
