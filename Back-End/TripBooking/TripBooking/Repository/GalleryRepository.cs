using TripBooking.Exceptions;
using TripBooking.Interfaces;
using TripBooking.Models;
using TripBooking.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TripBooking.Repos
{
    public class GalleryRepository : ICrud<Gallery, IdDTO>, IImageRepo<Gallery, GalleryFormModule>
    {
        private readonly TripBookingContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public GalleryRepository(TripBookingContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<Gallery?> Add(Gallery item)
        {
            /* try
             {*/
            var newPostGallery = _context.Gallery.SingleOrDefault(h => h.Id == item.Id);
            if (newPostGallery == null)
            {
                await _context.Gallery.AddAsync(item);
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

        public async Task<Gallery?> Delete(IdDTO item)
        {
            try
            {

                var Gallery = await _context.Gallery.ToListAsync();
                var myPostGallery = Gallery.FirstOrDefault(h => h.Id == item.IdInt);
                if (myPostGallery != null)
                {
                    _context.Gallery.Remove(myPostGallery);
                    await _context.SaveChangesAsync();
                    return myPostGallery;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<Gallery>?> GetAll()
        {
            try
            {
                var Gallery = await _context.Gallery.ToListAsync();
                if (Gallery != null)
                    return Gallery;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Gallery?> GetValue(IdDTO item)
        {
            try
            {
                var Gallery = await _context.Gallery.ToListAsync();
                var PostGallery = Gallery.SingleOrDefault(h => h.Id == item.IdInt);
                if (PostGallery != null)
                    return PostGallery;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Gallery?> Update(Gallery item)
        {
            try
            {
                var Gallery = await _context.Gallery.ToListAsync();
                var PostGallery = Gallery.SingleOrDefault(h => h.Id == item.Id);
                if (PostGallery != null)
                {
                    PostGallery.AdminId = item.AdminId != null ? item.AdminId : PostGallery.AdminId;
                    PostGallery.AdminImage = item.AdminImage != null ? item.AdminImage : PostGallery.AdminImage;
                    PostGallery.ImageType = item.ImageType != null ? item.ImageType : PostGallery.ImageType;

                    _context.Gallery.Update(PostGallery);
                    await _context.SaveChangesAsync();
                    return PostGallery;
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Gallery> PostImage([FromForm] GalleryFormModule postGalleryFormModule)
        {
            if (postGalleryFormModule == null)
            {
                throw new ArgumentException("Invalid file");
            }
            if(postGalleryFormModule.FormFile==null)
            {
                throw new ArgumentException("Invalid file");

            }

            postGalleryFormModule.AdminImage = await SaveImage(postGalleryFormModule.FormFile);
            var newPostGallery = new Gallery();
            newPostGallery.AdminId = postGalleryFormModule.AdminId;
            newPostGallery.ImageType = postGalleryFormModule.ImageType;
            
            newPostGallery.AdminImage = postGalleryFormModule.AdminImage;


            _context.Gallery.Add(newPostGallery);
            await _context.SaveChangesAsync();
            return newPostGallery;
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
