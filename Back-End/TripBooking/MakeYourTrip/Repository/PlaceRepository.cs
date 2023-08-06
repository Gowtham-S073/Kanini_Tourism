using TripBooking.Exceptions;
using TripBooking.Interfaces;
using TripBooking.Models;
using TripBooking.Models.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TripBooking.Repos
{
    public class PlaceRepository: ICrud<Place, IdDTO>
    {
        private readonly TripBookingContext _context;

        public PlaceRepository(TripBookingContext context)
        {
            _context = context;
        }
        public async Task<Place?> Add(Place item)
        {
           /* try
            {*/
                var newPlaceMaster = _context.Place.SingleOrDefault(h => h.Id == item.Id);
                if (newPlaceMaster == null)
                {
                    await _context.Place.AddAsync(item);
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

        public async Task<Place?> Delete(IdDTO item)
        {
            try
            {

                var Place = await _context.Place.ToListAsync();
                var myPlace = Place.FirstOrDefault(h => h.Id == item.IdInt);
                if (myPlace != null)
                {
                    _context.Place.Remove(myPlace);
                    await _context.SaveChangesAsync();
                    return myPlace;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<Place>?> GetAll()
        {
            try
            {
                var Place = await _context.Place.ToListAsync();
                if (Place != null)
                    return Place;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Place?> GetValue(IdDTO item)
        {
            try
            {
                var Place = await _context.Place.ToListAsync();
                var PlaceMaster = Place.SingleOrDefault(h => h.Id == item.IdInt);
                if (PlaceMaster != null)
                    return PlaceMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Place?> Update(Place item)
        {
            try
            {
                var Place = await _context.Place.ToListAsync();
                var PlaceMaster = Place.SingleOrDefault(h => h.Id == item.Id);
                if (PlaceMaster != null)
                {
                    PlaceMaster.PlaceName = item.PlaceName != null ? item.PlaceName : PlaceMaster.PlaceName;
                    _context.Place.Update(PlaceMaster);
                    await _context.SaveChangesAsync();
                    return PlaceMaster;
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
