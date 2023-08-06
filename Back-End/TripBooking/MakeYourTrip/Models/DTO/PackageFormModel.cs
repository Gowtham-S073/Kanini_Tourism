namespace TripBooking.Models.DTO
{
    public class PackageFormModel
    {
        public int Id { get; set; }

        public decimal? PackagePrice { get; set; }

        public string? PackageName { get; set; }

        public int? TravelAgentId { get; set; }

        public string? Region { get; set; }

        public int? Duration { get; set; }

        public string? Imagepath { get; set; }
        public IFormFile? FormFile { get; set; }
    }
}
