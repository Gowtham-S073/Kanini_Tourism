using System;
using System.Collections.Generic;

namespace TripBooking.Models;

public partial class Package
{
    public int Id { get; set; }

    public decimal? PackagePrice { get; set; }

    public string? PackageName { get; set; }

    public int? Duration { get; set; }

    public int? TravelAgentId { get; set; }

    public string? Region { get; set; }

    public string? Imagepath { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<PackageDetails> PackageDetails { get; set; } = new List<PackageDetails>();

    public virtual User? TravelAgent { get; set; }
}
