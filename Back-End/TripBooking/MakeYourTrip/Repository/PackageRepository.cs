using TripBooking.Exceptions;
using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Repos
{
    public class PackageRepository : ICrud<Package, IdDTO>, IImageRepo<Package, PackageFormModel>
    {
        private readonly TripBookingContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public PackageRepository(TripBookingContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment= hostEnvironment;
        }
        public async Task<Package?> Add(Package item)
        {
            /* try
             {*/
            var newPackageMaster = _context.Package.SingleOrDefault(h => h.Id == item.Id);
            if (newPackageMaster == null)
            {
                await _context.Package.AddAsync(item);
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

        public async Task<Package?> Delete(IdDTO item)
        {
            try
            {

                var Package = await _context.Package.ToListAsync();
                var myPackage = Package.FirstOrDefault(h => h.Id == item.IdInt);
                if (myPackage != null)
                {
                    _context.Package.Remove(myPackage);
                    await _context.SaveChangesAsync();
                    return myPackage;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<Package>?> GetAll()
        {
            try
            {
                var Package = await _context.Package.ToListAsync();
                if (Package != null)
                    return Package;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Package?> GetValue(IdDTO item)
        {
            try
            {
                var Package = await _context.Package.ToListAsync();
                var PackageMaster = Package.SingleOrDefault(h => h.Id == item.IdInt);
                if (PackageMaster != null)
                    return PackageMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Package?> Update(Package item)
        {
            try
            {
                var Package = await _context.Package.ToListAsync();
                var PackageMaster = Package.SingleOrDefault(h => h.Id == item.Id);
                if (PackageMaster != null)
                {
                    PackageMaster.PackagePrice = item.PackagePrice != null ? item.PackagePrice : PackageMaster.PackagePrice;
                    PackageMaster.PackageName = item.PackageName != null ? item.PackageName : PackageMaster.PackageName;
                    PackageMaster.TravelAgentId = item.TravelAgentId != null ? item.TravelAgentId : PackageMaster.TravelAgentId;
                    PackageMaster.Region = item.Region != null ? item.Region : PackageMaster.Region;

                    _context.Package.Update(PackageMaster);
                    await _context.SaveChangesAsync();
                    return PackageMaster;
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Package> PostImage([FromForm] PackageFormModel packageFormModel)
        {
            if (packageFormModel.FormFile == null)
            {
                throw new ArgumentException("Invalid file");
            }

            packageFormModel.Imagepath = await SaveImage(packageFormModel.FormFile);
            var newPackageMaster = new Package();
            newPackageMaster.PackagePrice= packageFormModel.PackagePrice;
            newPackageMaster.PackageName = packageFormModel.PackageName;
            newPackageMaster.TravelAgentId = packageFormModel.TravelAgentId;
            newPackageMaster.Region = packageFormModel.Region;
            newPackageMaster.Duration= packageFormModel.Duration;
            newPackageMaster.Imagepath = packageFormModel.Imagepath;


            _context.Package.Add(newPackageMaster);
            await _context.SaveChangesAsync();
            return newPackageMaster;
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
