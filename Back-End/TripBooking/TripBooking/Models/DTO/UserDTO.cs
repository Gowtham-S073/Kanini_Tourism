using System.ComponentModel.DataAnnotations;

namespace TripBooking.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        public byte[]? Hashkey { get; set; }

        public byte[]? Password { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public string? Role { get; set; }
    }
}
