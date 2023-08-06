namespace TripBooking.Models.DTO
{
    public class HotelFormModule
    {
        public int Id { get; set; }

        public string? HotelName { get; set; }

        public int? PlaceId { get; set; }

        public string? HotelImagepath { get; set; }
        public IFormFile? FormFile { get; set; }

    }
}
