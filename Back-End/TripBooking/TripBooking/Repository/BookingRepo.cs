using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TripBooking.Models;
using TripBooking.Models.DTO;
using TripBooking.Custom_Exceptions;
using TripBooking.Interfaces;

namespace TripBooking.Repository
{
    public class BookingRepo : ICrud<Booking, IdDTO>
    {
        private readonly TripBookingContext _context;

        public BookingRepo(TripBookingContext context)
        {
            _context = context;
        }
        public async Task<Booking?> Add(Booking item)
        {
            try
            {
                var newBokoing = _context.Bookings.FirstOrDefault(h => h.Id == item.Id);  
                if(newBokoing == null)
                {
                    await _context.Bookings.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                return null;
            }
            catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }
        }

        public async Task<Booking?>Delete(IdDTO item)
        {
            try
            {
                var myBooking = await _context.Bookings.ToListAsync();
                var myBookingMaster = myBooking.FirstOrDefault(h => h.Id == item.IdInt);
                if (myBookingMaster != null)
                {
                    _context.Bookings.Remove(myBookingMaster);
                    await _context.SaveChangesAsync();
                    return myBookingMaster;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }
        public async Task<List<Booking>?> GetAll()
        {
            try
            {
                var myBookings = await _context.Bookings.ToListAsync();
                if (myBookings != null)
                    return myBookings;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Booking?> GetValue(IdDTO item)
        {
            try
            {
                var myBookings = await _context.Bookings.ToListAsync();
                var myBooking = myBookings.SingleOrDefault(h => h.Id == item.IdInt);
                if (myBooking != null)
                    return myBooking;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Booking?> Update(Booking item)
        {
            try
            {
                var myBookings = await _context.Bookings.ToListAsync();
                var myBooking = myBookings.SingleOrDefault(h => h.Id == item.Id);
                if (myBooking != null)
                {
                    myBooking.Feedback = item.Feedback
                        != null ? item.Feedback : myBooking.Feedback;
                     _context.Bookings.Update(myBooking);
                    await _context.SaveChangesAsync();
                    return myBooking;
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }
    }
}
