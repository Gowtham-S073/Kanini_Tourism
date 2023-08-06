using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using TripBooking.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace TripBooking.Repos
{
    public class PackageDetailsRepository : ICrud<PackageDetails, IdDTO>, IImageRepo<PackageDetails, PlaceFormModel>
    {   
        private readonly TripBookingContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PackageDetailsRepository(TripBookingContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<PackageDetails?> Add(PackageDetails item)
        {
            try
            {
               
                var newPackageDetailsMaster = _context.PackageDetails.FirstOrDefault(h => h.Id == item.Id);
                if (newPackageDetailsMaster == null)
                {
                    await _context.PackageDetails.AddAsync(item);
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

        public async Task<PackageDetails?> Delete(IdDTO item)
        {
            try
            {

                var PackageDetails = await _context.PackageDetails.ToListAsync();
                var myPackageDetails = PackageDetails.FirstOrDefault(h => h.Id == item.IdInt);
                if (myPackageDetails != null)
                {
                    _context.PackageDetails.Remove(myPackageDetails);
                    await _context.SaveChangesAsync();
                    return myPackageDetails;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<PackageDetails>?> GetAll()
        {
            try
            {
                var PackageDetails = await _context.PackageDetails.ToListAsync();
                if (PackageDetails != null)
                    return PackageDetails;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<PackageDetails?> GetValue(IdDTO item)
        {
            try
            {
                var PackageDetails = await _context.PackageDetails.ToListAsync();
                var PackageDetailsMaster = PackageDetails.SingleOrDefault(h => h.Id == item.IdInt);
                if (PackageDetailsMaster != null)
                    return PackageDetailsMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<PackageDetails?> Update(PackageDetails item)
        {
            try
            {
                var PackageDetails = await _context.PackageDetails.ToListAsync();
                var PackageDetailsMaster = PackageDetails.SingleOrDefault(h => h.Id == item.Id);
                if (PackageDetailsMaster != null)
                {
                    PackageDetailsMaster.PackageId = item.PackageId != null ? item.PackageId : PackageDetailsMaster.PackageId;
                    PackageDetailsMaster.PlaceId = item.PlaceId != null ? item.PlaceId : PackageDetailsMaster.PlaceId;
                    PackageDetailsMaster.DayNumber = item.DayNumber != null ? item.DayNumber : PackageDetailsMaster.DayNumber;

                    _context.PackageDetails.Update(PackageDetailsMaster);
                    await _context.SaveChangesAsync();
                    return PackageDetailsMaster;
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<PackageDetails> PostImage([FromForm] PlaceFormModel placeFormModel)
        {
            if (placeFormModel.FormFile == null)
            {
                throw new ArgumentException("Invalid file");
            }

            string PlaceImagepath = await SaveImage(placeFormModel.FormFile);
            var pack = new PackageDetails();
            pack.PackageId = placeFormModel.PackageId;
            pack.PlaceId=placeFormModel.PlaceId;
            pack.DayNumber= placeFormModel.DayNumber;
            pack.PlaceImagepath = PlaceImagepath;
            pack.Itinerary = placeFormModel.Itinerary;
            _context.PackageDetails.Add(pack);
            await _context.SaveChangesAsync();
            return pack;
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
