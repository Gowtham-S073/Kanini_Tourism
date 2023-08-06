namespace TripBooking.Models.DTO
{
    public class VehicleFormModel
    {
        public int Id { get; set; }

        public int? VehicleId { get; set; }

        public decimal? CarPrice { get; set; }

        public int? PlaceId { get; set; }

        public string? VehicleImagepath { get; set; }
        public IFormFile? FormFile { get; set; }

    }
}
