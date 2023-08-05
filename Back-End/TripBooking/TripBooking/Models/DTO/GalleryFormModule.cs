namespace TripBooking.Models.DTO
{
    public class GalleryFormModule
    {
        public int Id { get; set; }

        public int? AdminId { get; set; }

        public string? AdminImage { get; set; }

        public string? ImageType { get; set; }
        public IFormFile? FormFile { get; set; }

    }
}
