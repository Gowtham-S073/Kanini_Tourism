namespace TripBooking.Models.DTO
{
    public class PlaceDTO
    {
        public int placeId { get; set; }

        public string? PlaceName { get; set; }
        public int? DayNumber { get; set; }
        public string? PlaceImagepath { get; set; }


        public List<HotelDTO>? HotelList { get; set; }
        public List<VehicleDTO>? VechileList { get; set; }


    }
}
