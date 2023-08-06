using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using TripBooking.Repos;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Services
{
    public class GalleryService: IGalleryService
    {
        private readonly ICrud<Gallery, IdDTO> _PostGalleryRepo;
        private readonly IImageRepo<Gallery, GalleryFormModule> _imageRepo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GalleryService(ICrud<Gallery, IdDTO> postGalleryRepo, 
            IImageRepo<Gallery, GalleryFormModule> imageRepo, IWebHostEnvironment hostEnvironment)
        {
            _PostGalleryRepo=postGalleryRepo;
            _imageRepo=imageRepo;
            _hostEnvironment=hostEnvironment;
        }


        public async Task<Gallery?> Add_Gallery(Gallery PostGallery)
        {
            var PostGallerytable = await _PostGalleryRepo.GetAll();
            var newPostGallery = PostGallerytable?.SingleOrDefault(h => h.Id == PostGallery.Id);
            if (newPostGallery == null)
            {
                var myPostGallery = await _PostGalleryRepo.Add(PostGallery);
                if (myPostGallery != null)
                    return myPostGallery;
            }
            return null;

        }
        public async Task<List<Gallery>?> Get_All_Gallery()
        {
            var PostGallerys = await _PostGalleryRepo.GetAll();
            var images = await _PostGalleryRepo.GetAll();
            var imageList = new List<Gallery>();
            foreach (var image in images)
            {
                var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(uploadsFolder, image.AdminImage);

                var imageBytes = System.IO.File.ReadAllBytes(filePath);
                var tourData = new Gallery
                {
                    Id = image.Id,
                    AdminId = image.AdminId,
                   
                    ImageType = image.ImageType,

                    AdminImage = Convert.ToBase64String(imageBytes)
                };
                imageList.Add(tourData);
            }
            return imageList;

        }

        public async Task<Gallery?> View_Gallery(IdDTO idDTO)
        {
            var PostGallery = await _PostGalleryRepo.GetValue(idDTO);
            return PostGallery;
        }

        public async Task<Gallery> PostImage([FromForm] GalleryFormModule postGalleryFormModule)
        {
            if (postGalleryFormModule == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _imageRepo.PostImage(postGalleryFormModule);
            if (item == null)
            {
                return null;
            }
            return item;
        }



    }
}
