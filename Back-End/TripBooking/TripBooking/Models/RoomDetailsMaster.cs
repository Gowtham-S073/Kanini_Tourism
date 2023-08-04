using System.ComponentModel.DataAnnotations;

namespace TripBooking.Models
{
    public partial class RoomDetailsMaster
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "RoomTypeId is required.")]
        public int? RoomTypeId { get; set; }

        [Required(ErrorMessage = "HotelId is required.")]
        public int? HotelId { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Hotel is required.")]
        public virtual HotelMaster? Hotel { get; set; }

        [Required(ErrorMessage = "RoomType is required.")]
        public virtual RoomTypeMaster? RoomType { get; set; }

        public virtual ICollection<RoomBooking> RoomBookings { get; set; } = new List<RoomBooking>();
    }
}
