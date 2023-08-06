using TripBooking.Exceptions;
using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Repos
{
    public class VehicleDetailsRepository : ICrud<VehicleDetails, IdDTO>, IImageRepo<VehicleDetails, VehicleFormModel>
    {
        private readonly TripBookingContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public VehicleDetailsRepository(TripBookingContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<VehicleDetails?> Add(VehicleDetails item)
        {
            try
            {

                var newVehicleDetails = _context.VehicleDetails.FirstOrDefault(h => h.Id == item.Id);
                if (newVehicleDetails == null)
                {
                    await _context.VehicleDetails.AddAsync(item);
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

        public async Task<VehicleDetails?> Delete(IdDTO item)
        {
            try
            {

                var VehicleDetails = await _context.VehicleDetails.ToListAsync();
                var myVehicleDetails = VehicleDetails.FirstOrDefault(h => h.Id == item.IdInt);
                if (myVehicleDetails != null)
                {
                    _context.VehicleDetails.Remove(myVehicleDetails);
                    await _context.SaveChangesAsync();
                    return myVehicleDetails;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<VehicleDetails>?> GetAll()
        {
            try
            {
                var VehicleDetails = await _context.VehicleDetails.ToListAsync();
                if (VehicleDetails != null)
                    return VehicleDetails;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<VehicleDetails?> GetValue(IdDTO item)
        {
            try
            {
                var VehicleDetails = await _context.VehicleDetails.ToListAsync();
                var VehicleDetailsMaster = VehicleDetails.SingleOrDefault(h => h.Id == item.IdInt);
                if (VehicleDetails != null)
                    return VehicleDetailsMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<VehicleDetails?> Update(VehicleDetails item)
        {
            try
            {
                var VehicleDetails = await _context.VehicleDetails.ToListAsync();
                var VehicleDetailsMaster = VehicleDetails.SingleOrDefault(h => h.Id == item.Id);
                if (VehicleDetailsMaster != null)
                {
                    VehicleDetailsMaster.VehicleId = item.VehicleId != null ? item.VehicleId : VehicleDetailsMaster.VehicleId;
                    VehicleDetailsMaster.PlaceId = item.PlaceId != null ? item.PlaceId : VehicleDetailsMaster.PlaceId;
                    VehicleDetailsMaster.CarPrice = item.CarPrice != null ? item.CarPrice : VehicleDetailsMaster.CarPrice;

                    _context.VehicleDetails.Update(VehicleDetailsMaster);
                    await _context.SaveChangesAsync();
                    return VehicleDetailsMaster;
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<VehicleDetails> PostImage([FromForm] VehicleFormModel vehicleFormModel)
        {
            if (vehicleFormModel.FormFile == null)
            {
                throw new ArgumentException("Invalid file");
            }

            string VehicleImagepath1 = await SaveImage(vehicleFormModel.FormFile);
            var vehicle = new VehicleDetails();
            vehicle.VehicleId = vehicleFormModel.VehicleId;
            vehicle.CarPrice = vehicleFormModel.CarPrice;
            vehicle.PlaceId = vehicleFormModel.PlaceId;
            vehicle.VehicleImagepath = VehicleImagepath1;
            _context.VehicleDetails.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
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
