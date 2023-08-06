namespace TripBooking.Models.DTO
{
    public class PackageDTO
    {
        public decimal? PackagePrice { get; set; }

        public string? PackageName { get; set; }

        public int? TravelAgentId { get; set; }

        public string? Region { get; set; }

        public string? Imagepath { get; set; }


        public List<PlaceDTO>? placeList { get; set; }





    }
}
