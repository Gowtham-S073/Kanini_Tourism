using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TripBooking.Models
{
    public partial class PlaceMaster
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Place Name is required.")]
        [StringLength(100, ErrorMessage = "Place Name cannot exceed 100 characters.")]
        public string? PlaceName { get; set; }

        public virtual ICollection<HotelMaster> HotelMasters { get; set; } = new List<HotelMaster>();

        public virtual ICollection<PackageDetailsMaster> PackageDetailsMasters { get; set; } = new List<PackageDetailsMaster>();

        public virtual ICollection<VehicleDetailsMaster> VehicleDetailsMasters { get; set; } = new List<VehicleDetailsMaster>();
    }
}
