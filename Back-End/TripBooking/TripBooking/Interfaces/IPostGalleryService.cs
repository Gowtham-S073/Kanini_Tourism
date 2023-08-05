using TripBooking.Models.DTO;
using TripBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Interfaces
{
    public interface IGalleryService
    {
        Task<Gallery?> Add_Gallery(Gallery PostGallery);

        Task<List<Gallery>?> Get_All_Gallery();
        Task<Gallery?> View_Gallery(IdDTO idDTO);

        
        Task<Gallery> PostImage([FromForm] GalleryFormModule postGalleryFormModule);

    }
}
