using TripBooking.Exceptions;
using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Repos
{
    public class HotelRepository : ICrud<Hotel, IdDTO>, IImageRepo<Hotel, HotelFormModule>
    {
        private readonly TripBookingContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public HotelRepository(TripBookingContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<Hotel?> Add(Hotel item)
        {
            /* try
             {*/
            var newHotel = _context.Hotel.SingleOrDefault(h => h.Id == item.Id);
            if (newHotel == null)
            {
                await _context.Hotel.AddAsync(item);
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

        public async Task<Hotel?> Delete(IdDTO item)
        {
            try
            {

                var Hotel = await _context.Hotel.ToListAsync();
                var myHotel = Hotel.FirstOrDefault(h => h.Id == item.IdInt);
                if (myHotel != null)
                {
                    _context.Hotel.Remove(myHotel);
                    await _context.SaveChangesAsync();
                    return myHotel;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<Hotel>?> GetAll()
        {
            try
            {
                var Hotel = await _context.Hotel.ToListAsync();
                if (Hotel != null)
                    return Hotel;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Hotel?> GetValue(IdDTO item)
        {
            try
            {
                var Hotel = await _context.Hotel.ToListAsync();
                var HotelMaster = Hotel.SingleOrDefault(h => h.Id == item.IdInt);
                if (HotelMaster != null)
                    return HotelMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Hotel?> Update(Hotel item)
        {
            try
            {
                var Hotel = await _context.Hotel.ToListAsync();
                var HotelMaster = Hotel.SingleOrDefault(h => h.Id == item.Id);
                if (HotelMaster != null)
                {
                    HotelMaster.HotelName = item.HotelName != null ? item.HotelName : HotelMaster.HotelName;
                    HotelMaster.PlaceId = item.PlaceId != null ? item.PlaceId : HotelMaster.PlaceId;
                    
                    _context.Hotel.Update(HotelMaster);
                    await _context.SaveChangesAsync();
                    return HotelMaster;
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Hotel> PostImage([FromForm] HotelFormModule hotelFormModule)
        {
            if (hotelFormModule.FormFile == null)
            {
                throw new ArgumentException("Invalid file");
            }

            string HotelImagepath1 = await SaveImage(hotelFormModule.FormFile);
            var hotel = new Hotel();
            hotel.HotelName = hotelFormModule.HotelName;
            hotel.PlaceId = hotelFormModule.PlaceId;
            hotel.HotelImagepath = HotelImagepath1;
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }


        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot/Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }


    }
}
