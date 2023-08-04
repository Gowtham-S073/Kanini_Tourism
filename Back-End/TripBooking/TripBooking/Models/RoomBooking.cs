using System.ComponentModel.DataAnnotations;

namespace TripBooking.Models
{
    public partial class RoomBooking
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "RoomDetailsId is required.")]
        public int? RoomDetailsId { get; set; }

        [Required(ErrorMessage = "BookingId is required.")]
        public int? BookingId { get; set; }

        [Required(ErrorMessage = "Booking is required.")]
        public virtual Booking? Booking { get; set; }

        [Required(ErrorMessage = "RoomDetails is required.")]
        public virtual RoomDetailsMaster? RoomDetails { get; set; }
    }
}
