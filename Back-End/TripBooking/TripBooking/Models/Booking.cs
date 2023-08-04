using System.ComponentModel.DataAnnotations;

namespace TripBooking.Models
{
    public partial class Booking
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Package Master ID is required.")]
        public int? PackageMasterId { get; set; }

        [MaxLength(500, ErrorMessage = "Feedback cannot exceed 500 characters.")]
        public string? Feedback { get; set; }

        [Required(ErrorMessage = "Total Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Total Amount must be a positive number.")]
        public decimal? TotalAmount { get; set; }

        public virtual PackageMaster? PackageMaster { get; set; }

        public virtual User? User { get; set; }

        public virtual ICollection<RoomBooking> RoomBookings { get; set; } = new List<RoomBooking>();

        public virtual ICollection<VehicleBooking> VehicleBookings { get; set; } = new List<VehicleBooking>();
    }
}
