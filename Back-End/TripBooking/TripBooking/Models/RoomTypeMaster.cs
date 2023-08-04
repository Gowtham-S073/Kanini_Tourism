using System.ComponentModel.DataAnnotations;

namespace TripBooking.Models
{
    public partial class RoomTypeMaster
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "RoomType is required.")]
        public string? RoomType { get; set; }

        public virtual ICollection<RoomDetailsMaster> RoomDetailsMasters { get; set; } = new List<RoomDetailsMaster>();
    }
}
