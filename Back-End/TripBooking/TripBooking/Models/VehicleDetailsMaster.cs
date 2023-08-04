using System.ComponentModel.DataAnnotations;

namespace TripBooking.Models
{
    public partial class VehicleDetailsMaster
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "VehicleId is required.")]
        public int? VehicleId { get; set; }

        [Required(ErrorMessage = "CarPrice is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "CarPrice must be a non-negative value.")]
        public decimal? CarPrice { get; set; }

        [Required(ErrorMessage = "PlaceId is required.")]
        public int? PlaceId { get; set; }

        public virtual PlaceMaster? Place { get; set; }

        public virtual VehicleMaster? Vehicle { get; set; }

        public virtual ICollection<VehicleBooking> VehicleBookings { get; set; } = new List<VehicleBooking>();
    }
}
