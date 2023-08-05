/*using TripBooking.Interfaces;
using TripBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TripBooking.Repos
{
    public class ImageRepo: IImageRepo
    {
        private readonly TripBookingContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public ImageRepo(TripBookingContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<PackageMaster> PostPackageImage([FromForm] PackageMaster packageMaster)
        {
            if (packageMaster == null)
            {
                throw new ArgumentException("Invalid file");
            }

            packageMaster.Imagepath = await SaveImage(packageMaster.HotelImage);
            _context.Package.Add(packageMaster);
            await _context.SaveChangesAsync();
            return packageMaster;
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
*/