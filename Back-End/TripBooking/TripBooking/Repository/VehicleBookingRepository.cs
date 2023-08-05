using TripBooking.Exceptions;
using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TripBooking.Repos
{
    public class VehicleBookingRepository : ICrud<VehicleBooking, IdDTO>
    {
        private readonly TripBookingContext _context;

        public VehicleBookingRepository(TripBookingContext context)
        {
            _context = context;
        }
        public async Task<VehicleBooking?> Add(VehicleBooking item)
        {
            /* try
             {*/
            var newVehicleBooking = _context.VehicleBookings.SingleOrDefault(h => h.Id == item.Id);
            if (newVehicleBooking == null)
            {
                await _context.VehicleBookings.AddAsync(item);
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

        public async Task<VehicleBooking?> Delete(IdDTO item)
        {
            try
            {

                var VehicleBookings = await _context.VehicleBookings.ToListAsync();
                var myVehicleBooking = VehicleBookings.FirstOrDefault(h => h.Id == item.IdInt);
                if (myVehicleBooking != null)
                {
                    _context.VehicleBookings.Remove(myVehicleBooking);
                    await _context.SaveChangesAsync();
                    return myVehicleBooking;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<VehicleBooking>?> GetAll()
        {
            try
            {
                var VehicleBookings = await _context.VehicleBookings.ToListAsync();
                if (VehicleBookings != null)
                    return VehicleBookings;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<VehicleBooking?> GetValue(IdDTO item)
        {
            try
            {
                var VehicleBookings = await _context.VehicleBookings.ToListAsync();
                var VehicleBooking = VehicleBookings.SingleOrDefault(h => h.Id == item.IdInt);
                if (VehicleBooking != null)
                    return VehicleBooking;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<VehicleBooking?> Update(VehicleBooking item)
        {
            try
            {
                var VehicleBookings = await _context.VehicleBookings.ToListAsync();
                var VehicleBooking = VehicleBookings.SingleOrDefault(h => h.Id == item.Id);
                if (VehicleBooking != null)
                {
                    VehicleBooking.VehicleDetailsId = item.VehicleDetailsId != null ? item.VehicleDetailsId : VehicleBooking.VehicleDetailsId;
                   


                    _context.VehicleBookings.Update(VehicleBooking);
                    await _context.SaveChangesAsync();
                    return VehicleBooking;
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
