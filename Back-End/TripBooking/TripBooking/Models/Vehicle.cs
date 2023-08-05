using System;
using System.Collections.Generic;

namespace TripBooking.Models;

public partial class Vehicle
{
    public int Id { get; set; }

    public string? VehicleName { get; set; }

    public int? NumberOfSeats { get; set; }

    public virtual ICollection<VehicleDetails> VehicleDetails { get; set; } = new List<VehicleDetails>();
}
