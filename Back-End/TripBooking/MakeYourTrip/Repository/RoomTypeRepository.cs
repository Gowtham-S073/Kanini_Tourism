using TripBooking.Exceptions;
using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TripBooking.Repos
{
    public class RoomTypeRepository : ICrud<RoomType, IdDTO>
    {
        private readonly TripBookingContext _context;

        public RoomTypeRepository(TripBookingContext context)
        {
            _context = context;
        }
        public async Task<RoomType?> Add(RoomType item)
        {
            /* try
             {*/
            var newRoomType = _context.RoomTypes.SingleOrDefault(h => h.Id == item.Id);
            if (newRoomType == null)
            {
                await _context.RoomTypes.AddAsync(item);
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

        public async Task<RoomType?> Delete(IdDTO item)
        {
            try
            {

                var RoomTypes = await _context.RoomTypes.ToListAsync();
                var myRoomType = RoomTypes.FirstOrDefault(h => h.Id == item.IdInt);
                if (myRoomType != null)
                {
                    _context.RoomTypes.Remove(myRoomType);
                    await _context.SaveChangesAsync();
                    return myRoomType;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<RoomType>?> GetAll()
        {
            try
            {
                var RoomTypes = await _context.RoomTypes.ToListAsync();
                if (RoomTypes != null)
                    return RoomTypes;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<RoomType?> GetValue(IdDTO item)
        {
            try
            {
                var RoomTypes = await _context.RoomTypes.ToListAsync();
                var RoomType = RoomTypes.SingleOrDefault(h => h.Id == item.IdInt);
                if (RoomType != null)
                    return RoomType;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<RoomType?> Update(RoomType item)
        {
            try
            {
                var RoomTypes = await _context.RoomTypes.ToListAsync();
                var RoomType = RoomTypes.SingleOrDefault(h => h.Id == item.Id);
                if (RoomType != null)
                {
                    RoomType.RoomTypes = item.RoomTypes != null ? item.RoomTypes : RoomType.RoomTypes;
                   

                    _context.RoomTypes.Update(RoomType);
                    await _context.SaveChangesAsync();
                    return RoomType;
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
