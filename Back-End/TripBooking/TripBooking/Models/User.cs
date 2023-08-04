using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TripBooking.Models
{
    public partial class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(30, ErrorMessage = "Username cannot exceed 30 characters.")]
        public string? Username { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        [MaxLength(13, ErrorMessage = "Phone number cannot exceed 13 characters.")]
        public string? Phone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(64, ErrorMessage = "Email address cannot exceed 64 characters.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Hashkey is required.")]
        public byte[]? Hashkey { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public byte[]? Password { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        [MaxLength(50, ErrorMessage = "Role cannot exceed 50 characters.")]
        public string? Role { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public virtual ICollection<PackageMaster> PackageMasters { get; set; } = new List<PackageMaster>();
    }
}
