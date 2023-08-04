using System.ComponentModel.DataAnnotations;

namespace TripBooking.Models
{
    public partial class VehicleMaster
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "VehicleName is required.")]
        public string? VehicleName { get; set; }

        [Required(ErrorMessage = "NumberOfSeats is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "NumberOfSeats must be a positive value.")]
        public int? NumberOfSeats { get; set; }

        public virtual ICollection<VehicleDetailsMaster> VehicleDetailsMasters { get; set; } = new List<VehicleDetailsMaster>();
    }
}
    