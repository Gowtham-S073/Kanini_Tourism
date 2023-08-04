using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TripBooking.Models
{
    public partial class PackageMaster
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Package Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Package Price must be a non-negative value.")]
        public decimal? PackagePrice { get; set; }

        [Required(ErrorMessage = "Package Name is required.")]
        [MaxLength(100, ErrorMessage = "Package Name cannot exceed 100 characters.")]
        public string? PackageName { get; set; }

        [Required(ErrorMessage = "Travel Agent ID is required.")]
        public int? TravelAgentId { get; set; }

        [Required(ErrorMessage = "Region is required.")]
        [MaxLength(50, ErrorMessage = "Region cannot exceed 50 characters.")]
        public string? Region { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public virtual ICollection<PackageDetailsMaster> PackageDetailsMasters { get; set; } = new List<PackageDetailsMaster>();

        public virtual User? TravelAgent { get; set; }
    }
}
