using System.ComponentModel.DataAnnotations;

namespace TripBooking.Models
{
    public partial class PackageDetailsMaster
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Package ID is required.")]
        public int? PackageId { get; set; }

        [Required(ErrorMessage = "Place ID is required.")]
        public int? PlaceId { get; set; }

        [Required(ErrorMessage = "Day Number is required.")]
        [MaxLength(50, ErrorMessage = "Day Number cannot exceed 50 characters.")]
        public string? DayNumber { get; set; }

        public virtual PackageMaster? Package { get; set; }

        public virtual PlaceMaster? Place { get; set; }
    }
}
