using TripBooking.Exceptions;
using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TripBooking.Repos
{
    public class VehicleRepository : ICrud<Vehicle, IdDTO>
    {
        private readonly TripBookingContext _context;

        public VehicleRepository(TripBookingContext context)
        {
            _context = context;
        }
        public async Task<Vehicle?> Add(Vehicle item)
        {
            /* try
             {*/
            var newVehicleMaster = _context.Vehicle.SingleOrDefault(h => h.Id == item.Id);
            if (newVehicleMaster == null)
            {
                await _context.Vehicle.AddAsync(item);
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

        public async Task<Vehicle?> Delete(IdDTO item)
        {
            try
            {

                var Vehicle = await _context.Vehicle.ToListAsync();
                var myVehicle = Vehicle.FirstOrDefault(h => h.Id == item.IdInt);
                if (myVehicle != null)
                {
                    _context.Vehicle.Remove(myVehicle);
                    await _context.SaveChangesAsync();
                    return myVehicle;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<Vehicle>?> GetAll()
        {
            try
            {
                var Vehicle = await _context.Vehicle.ToListAsync();
                if (Vehicle != null)
                    return Vehicle;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Vehicle?> GetValue(IdDTO item)
        {
            try
            {
                var Vehicle = await _context.Vehicle.ToListAsync();
                var VehicleMaster = Vehicle.SingleOrDefault(h => h.Id == item.IdInt);
                if (VehicleMaster != null)
                    return VehicleMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Vehicle?> Update(Vehicle item)
        {
            try
            {
                var Vehicle = await _context.Vehicle.ToListAsync();
                var VehicleMaster = Vehicle.SingleOrDefault(h => h.Id == item.Id);
                if (VehicleMaster != null)
                {
                    VehicleMaster.VehicleName = item.VehicleName != null ? item.VehicleName : VehicleMaster.VehicleName;
                    VehicleMaster.NumberOfSeats = item.NumberOfSeats != null ? item.NumberOfSeats : VehicleMaster.NumberOfSeats;
                    

                    _context.Vehicle.Update(VehicleMaster);
                    await _context.SaveChangesAsync();
                    return VehicleMaster;
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
