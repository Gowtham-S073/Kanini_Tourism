using System;
using System.Collections.Generic;

namespace TripBooking.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public byte[]? Hashkey { get; set; }

    public byte[]? Password { get; set; }

    public string? Role { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Package> Package { get; set; } = new List<Package>();

    public virtual ICollection<Gallery> Gallery { get; set; } = new List<Gallery>();
}
