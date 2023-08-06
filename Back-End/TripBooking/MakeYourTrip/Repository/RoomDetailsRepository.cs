using TripBooking.Exceptions;
using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TripBooking.Repos
{
    public class RoomDetailsRepository : ICrud<RoomDetails, IdDTO>
    {
        private readonly TripBookingContext _context;

        public RoomDetailsRepository(TripBookingContext context)
        {
            _context = context;
        }

        public async Task<RoomDetails?> Add(RoomDetails item)
        {
            try
            {

                var newRoomDetailsMaster = _context.RoomDetails.FirstOrDefault(h => h.Id == item.Id);
                if (newRoomDetailsMaster == null)
                {
                    await _context.RoomDetails.AddAsync(item);
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

        public async Task<RoomDetails?> Delete(IdDTO item)
        {
            try
            {

                var RoomDetailsMasters = await _context.RoomDetails.ToListAsync();
                var myRoomDetailsMaster = RoomDetailsMasters.FirstOrDefault(h => h.Id == item.IdInt);
                if (myRoomDetailsMaster != null)
                {
                    _context.RoomDetails.Remove(myRoomDetailsMaster);
                    await _context.SaveChangesAsync();
                    return myRoomDetailsMaster;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<RoomDetails>?> GetAll()
        {
            try
            {
                var RoomDetailsMasters = await _context.RoomDetails.ToListAsync();
                if (RoomDetailsMasters != null)
                    return RoomDetailsMasters;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<RoomDetails?> GetValue(IdDTO item)
        {
            try
            {
                var RoomDetailsMasters = await _context.RoomDetails.ToListAsync();
                var RoomDetailsMaster = RoomDetailsMasters.SingleOrDefault(h => h.Id == item.IdInt);
                if (RoomDetailsMaster != null)
                    return RoomDetailsMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<RoomDetails?> Update(RoomDetails item)
        {
            try
            {
                var RoomDetailsMasters = await _context.RoomDetails.ToListAsync();
                var RoomDetailsMaster = RoomDetailsMasters.SingleOrDefault(h => h.Id == item.Id);
                if (RoomDetailsMaster != null)
                {
                    RoomDetailsMaster.Price = item.Price != null ? item.Price : RoomDetailsMaster.Price;
                    RoomDetailsMaster.RoomTypeId = item.RoomTypeId != null ? item.RoomTypeId : RoomDetailsMaster.RoomTypeId;
                    RoomDetailsMaster.HotelId = item.HotelId != null ? item.HotelId : RoomDetailsMaster.HotelId;
                    RoomDetailsMaster.Description = item.Description != null ? item.Description : RoomDetailsMaster.Description;


                    _context.RoomDetails.Update(RoomDetailsMaster);
                    await _context.SaveChangesAsync();
                    return RoomDetailsMaster;
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
