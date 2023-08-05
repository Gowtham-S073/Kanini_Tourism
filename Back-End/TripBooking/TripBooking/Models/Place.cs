using System;
using System.Collections.Generic;

namespace TripBooking.Models;

public partial class Place
{
    public int Id { get; set; }

    public string? PlaceName { get; set; }

    public virtual ICollection<Hotel> Hotel { get; set; } = new List<Hotel>();

    public virtual ICollection<PackageDetails> PackageDetails { get; set; } = new List<PackageDetails>();

    public virtual ICollection<VehicleDetails> VehicleDetails { get; set; } = new List<VehicleDetails>();
}
