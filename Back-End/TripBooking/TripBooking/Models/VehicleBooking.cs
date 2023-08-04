using System.ComponentModel.DataAnnotations;

namespace TripBooking.Models
{
    public partial class VehicleBooking
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "VehicleDetailsId is required.")]
        public int? VehicleDetailsId { get; set; }

        [Required(ErrorMessage = "BookingId is required.")]
        public int? BookingId { get; set; }

        public virtual Booking? Booking { get; set; }

        public virtual VehicleDetailsMaster? VehicleDetails { get; set; }
    }
}
