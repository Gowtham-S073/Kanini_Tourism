using TripBooking.Exceptions;
using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TripBooking.Repos
{
    public class RoomBookingRepository : ICrud<RoomBooking, IdDTO>
    {
        private readonly TripBookingContext _context;

        public RoomBookingRepository(TripBookingContext context)
        {
            _context = context;
        }
        public async Task<RoomBooking?> Add(RoomBooking item)
        {
            /* try
             {*/
            var newRoomBooking = _context.RoomBookings.SingleOrDefault(h => h.Id == item.Id);
            if (newRoomBooking == null)
            {
                await _context.RoomBookings.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }

            return null;
            /* }*/
            /*catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }*/
        }

        public async Task<RoomBooking?> Delete(IdDTO item)
        {
            try
            {

                var RoomBookings = await _context.RoomBookings.ToListAsync();
                var myRoomBooking = RoomBookings.FirstOrDefault(h => h.Id == item.IdInt);
                if (myRoomBooking != null)
                {
                    _context.RoomBookings.Remove(myRoomBooking);
                    await _context.SaveChangesAsync();
                    return myRoomBooking;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<RoomBooking>?> GetAll()
        {
            try
            {
                var RoomBookings = await _context.RoomBookings.ToListAsync();
                if (RoomBookings != null)
                    return RoomBookings;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<RoomBooking?> GetValue(IdDTO item)
        {
            try
            {
                var RoomBookings = await _context.RoomBookings.ToListAsync();
                var RoomBooking = RoomBookings.SingleOrDefault(h => h.Id == item.IdInt);
                if (RoomBooking != null)
                    return RoomBooking;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<RoomBooking?> Update(RoomBooking item)
        {
            try
            {
                var RoomBookings = await _context.RoomBookings.ToListAsync();
                var RoomBooking = RoomBookings.SingleOrDefault(h => h.Id == item.Id);
                if (RoomBooking != null)
                {
                    RoomBooking.RoomDetailsId = item.RoomDetailsId != null ? item.RoomDetailsId : RoomBooking.RoomDetailsId;
                    


                    _context.RoomBookings.Update(RoomBooking);
                    await _context.SaveChangesAsync();
                    return RoomBooking;
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
